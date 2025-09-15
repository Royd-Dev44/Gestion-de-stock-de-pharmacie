using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Pharmacie.Models;

namespace Pharmacie.Data
{
    public class StockRepository
    {
        public static List<Stock> GetAll()
        {
            List<Stock> lots = new List<Stock>();

            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                                l.id AS IdLot,
                                a.id AS IdAchat,
                                m.nom AS NomMedicament,
                                l.quantite_total AS QuantiteTotal,
                                l.quantite_reste AS QuantiteRestante,
                                l.date_ajout AS DateAjout,
                                a.date_achat AS DateAchat,
                                a.total AS TotalAchat,
                                l.date_expiration AS DateExpiration,
                                a.id_utilisateur AS IdUtilisateur,
                                a.statut AS Statut
                            FROM lots l
                            JOIN medicament m ON l.id_medicament = m.id
                            JOIN achat a ON l.id_achat = a.id
                            ORDER BY a.id DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lots.Add(new Stock
                            {
                                IdLot = reader.GetInt32("IdLot"),
                                IdAchat = reader.GetInt32("IdAchat"),
                                NomMedicament = reader.GetString("NomMedicament"),
                                QuantiteTotal = reader.GetInt32("QuantiteTotal"),
                                QuantiteRestante = reader.GetInt32("QuantiteRestante"),
                                DateAjout = reader.GetDateTime("DateAjout"),
                                DateAchat = reader.GetDateTime("DateAchat"),
                                TotalAchat = reader.GetDecimal("TotalAchat"),
                                DateExpiration = reader.GetDateTime("DateExpiration"),
                                IdUtilisateur = reader.GetInt32("IdUtilisateur"),
                                Statut = reader.GetString("Statut")
                            });
                        }
                    }
                }
            }

            return lots;
        }

        public static bool Delete(int idLot)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM lots WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idLot);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public static bool UpdateLot(int idLot, int newQuantite, DateTime newDateExpiration, string newStatut)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                // 1. Mettre à jour la table LOTS
                string updateLotsQuery = @"
            UPDATE lots 
            SET quantite_total = @quantite,
                quantite_reste = @quantite,
                date_expiration = @dateExpiration
            WHERE id = @idLot";

                // 2. Mettre à jour la table ACHAT (pour le statut)
                string updateAchatQuery = @"
            UPDATE achat 
            SET statut = @statut
            WHERE id = (SELECT id_achat FROM lots WHERE id = @idLot)";

                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Exécuter la 1ère requête (lots)
                        using (MySqlCommand cmdLots = new MySqlCommand(updateLotsQuery, conn, transaction))
                        {
                            cmdLots.Parameters.AddWithValue("@quantite", newQuantite);
                            cmdLots.Parameters.AddWithValue("@dateExpiration", newDateExpiration);
                            cmdLots.Parameters.AddWithValue("@idLot", idLot);
                            cmdLots.ExecuteNonQuery();
                        }

                        // Exécuter la 2ème requête (achat)
                        using (MySqlCommand cmdAchat = new MySqlCommand(updateAchatQuery, conn, transaction))
                        {
                            cmdAchat.Parameters.AddWithValue("@statut", newStatut);
                            cmdAchat.Parameters.AddWithValue("@idLot", idLot);
                            cmdAchat.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public static Stock GetById(int idLot)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                        l.id AS IdLot,
                        a.id AS IdAchat,
                        m.nom AS NomMedicament,
                        l.quantite_total AS QuantiteTotal,
                        l.quantite_reste AS QuantiteRestante,
                        l.date_ajout AS DateAjout,
                        a.date_achat AS DateAchat,
                        a.total AS TotalAchat,
                        l.date_expiration AS DateExpiration,
                        a.id_utilisateur AS IdUtilisateur,
                        a.statut AS Statut
                    FROM lots l
                    JOIN medicament m ON l.id_medicament = m.id
                    JOIN achat a ON l.id_achat = a.id
                    WHERE l.id = @idLot";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idLot", idLot);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Stock
                            {
                                IdLot = reader.GetInt32("IdLot"),
                                IdAchat = reader.GetInt32("IdAchat"),
                                NomMedicament = reader.GetString("NomMedicament"),
                                QuantiteTotal = reader.GetInt32("QuantiteTotal"),
                                QuantiteRestante = reader.GetInt32("QuantiteRestante"),
                                DateAjout = reader.GetDateTime("DateAjout"),
                                DateAchat = reader.GetDateTime("DateAchat"),
                                TotalAchat = reader.GetDecimal("TotalAchat"),
                                DateExpiration = reader.GetDateTime("DateExpiration"),
                                IdUtilisateur = reader.GetInt32("IdUtilisateur"),
                                Statut = reader.GetString("Statut")
                            };
                        }
                    }
                }
            }
            return null;
        }
        public static int GetQuantiteDisponible(int idMedicament)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT COALESCE(SUM(quantite_reste), 0) 
                               FROM lots 
                               WHERE id_medicament = @idMedicament 
                               AND date_expiration >= CURDATE()";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idMedicament", idMedicament);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public static List<Lot> GetLotsByExpiration(int idMedicament)
        {
            List<Lot> lots = new List<Lot>();

            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT id, id_medicament, quantite_reste, date_expiration 
                               FROM lots 
                               WHERE id_medicament = @idMedicament 
                               AND quantite_reste > 0
                               AND date_expiration >= CURDATE()
                               ORDER BY date_expiration ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idMedicament", idMedicament);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lots.Add(new Lot
                            {
                                Id = reader.GetInt32("id"),
                                IdMedicament = reader.GetInt32("id_medicament"),
                                QuantiteRestante = reader.GetInt32("quantite_reste"),
                                DateExpiration = reader.GetDateTime("date_expiration")
                            });
                        }
                    }
                }
            }

            return lots;
        }
        public static bool UpdateQuantiteRestante(int idLot, int nouvelleQuantite)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE lots 
                               SET quantite_reste = @quantite 
                               WHERE id = @idLot";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@quantite", nouvelleQuantite);
                    cmd.Parameters.AddWithValue("@idLot", idLot);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
