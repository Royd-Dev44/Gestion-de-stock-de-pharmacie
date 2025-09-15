using MySql.Data.MySqlClient;
using Pharmacie.Data;
using Pharmacie.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacie.Data
{
    public static class VenteRepository
    {
        public static List<Vente> GetAll()
        {
            List<Vente> ventes = new List<Vente>();

            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id, id_client, id_utilisateur, total, date_vente FROM vente ORDER BY date_vente DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventes.Add(new Vente
                            {
                                Id = reader.GetInt32("id"),
                                IdClient = reader.IsDBNull(reader.GetOrdinal("id_client")) ?
                                          (int?)null : reader.GetInt32("id_client"),
                                IdUtilisateur = reader.GetInt32("id_utilisateur"),
                                Total = reader.GetDecimal("total"),
                                DateVente = reader.GetDateTime("date_vente")
                            });
                        }
                    }
                }
            }

            return ventes;
        }
        public static int Add(Vente vente, List<DetailVente> details)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Ajouter la vente
                        string venteQuery = @"INSERT INTO vente (id_client, id_utilisateur, total, date_vente) 
                                            VALUES (@id_client, @id_utilisateur, @total, @date_vente);
                                            SELECT LAST_INSERT_ID();";

                        int venteId;
                        using (MySqlCommand cmd = new MySqlCommand(venteQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id_client", vente.IdClient.HasValue ? (object)vente.IdClient.Value : DBNull.Value);
                            cmd.Parameters.AddWithValue("@id_utilisateur", SessionUtilisateur.Id);
                            cmd.Parameters.AddWithValue("@total", vente.Total);
                            cmd.Parameters.AddWithValue("@date_vente", vente.DateVente);

                            venteId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Ajouter les détails de vente et gérer les lots
                        foreach (var detail in details)
                        {
                            // Ajouter le détail de vente
                            string detailQuery = @"INSERT INTO detailvente (id_vente, id_medicament, quantite) 
                                                VALUES (@id_vente, @id_medicament, @quantite)";

                            using (MySqlCommand cmd = new MySqlCommand(detailQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id_vente", venteId);
                                cmd.Parameters.AddWithValue("@id_medicament", detail.IdMedicament);
                                cmd.Parameters.AddWithValue("@quantite", detail.Quantite);
                                cmd.ExecuteNonQuery();
                            }

                            // Gérer la déduction des lots (FIFO par date d'expiration)
                            DeduireQuantiteDesLots(detail.IdMedicament, detail.Quantite, conn, transaction);
                        }

                        transaction.Commit();
                        return venteId;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erreur lors de l'enregistrement de la vente: " + ex.Message);
                    }
                }
            }
        }
        private static void DeduireQuantiteDesLots(int idMedicament, int quantite, MySqlConnection conn, MySqlTransaction transaction)
        {
            // Récupérer les lots triés par date d'expiration croissante
            var lots = new List<Lot>();
            string query = @"SELECT id, quantite_reste, date_expiration 
                           FROM lots 
                           WHERE id_medicament = @idMedicament 
                           AND quantite_reste > 0
                           AND date_expiration >= CURDATE()
                           ORDER BY date_expiration ASC";

            using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@idMedicament", idMedicament);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lots.Add(new Lot
                        {
                            Id = reader.GetInt32("id"),
                            QuantiteRestante = reader.GetInt32("quantite_reste"),
                            DateExpiration = reader.GetDateTime("date_expiration")
                        });
                    }
                }
            }

            int quantiteRestanteADeduire = quantite;

            foreach (var lot in lots)
            {
                if (quantiteRestanteADeduire <= 0) break;

                int quantiteADeduire = Math.Min(quantiteRestanteADeduire, lot.QuantiteRestante);
                int nouvelleQuantite = lot.QuantiteRestante - quantiteADeduire;

                // Mettre à jour la quantité restante du lot
                string updateQuery = @"UPDATE lots 
                                      SET quantite_reste = @quantite 
                                      WHERE id = @idLot";

                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn, transaction))
                {
                    updateCmd.Parameters.AddWithValue("@quantite", nouvelleQuantite);
                    updateCmd.Parameters.AddWithValue("@idLot", lot.Id);
                    updateCmd.ExecuteNonQuery();
                }

                quantiteRestanteADeduire -= quantiteADeduire;
            }

            if (quantiteRestanteADeduire > 0)
            {
                throw new Exception($"Stock insuffisant pour le médicament ID {idMedicament}. Il manque {quantiteRestanteADeduire} unités.");
            }
        }
        public static DataTable GetAllWithDetails()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT v.id, v.id_client, c.nom AS client_nom, 
                        v.total, v.date_vente, u.id AS id_utilisateur, 
                        u.nom AS utilisateur_nom
                        FROM vente v
                        LEFT JOIN client c ON v.id_client = c.id
                        JOIN utilisateur u ON v.id_utilisateur = u.id
                        ORDER BY v.date_vente DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}
