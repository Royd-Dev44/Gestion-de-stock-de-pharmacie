using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Pharmacie.Models;

namespace Pharmacie.Data
{
    public class MedicamentRepository
    {
        // Méthode commune pour les requêtes de recherche
        private static List<Medicament> ExecuteMedicamentQuery(string query, MySqlParameter[] parameters = null)
        {
            var liste = new List<Medicament>();

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var medicament = new Medicament
                            {
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString("description"),
                                Prix = reader.GetDecimal("prix"),
                                IdLot = reader.IsDBNull(reader.GetOrdinal("id_lot")) ? 0 : reader.GetDecimal("id_lot"),
                                QuantiteRestante = reader.IsDBNull(reader.GetOrdinal("quantite_restante")) ? 0 : reader.GetInt32("quantite_restante"),
                                DateExpiration = reader.IsDBNull(reader.GetOrdinal("date_expiration")) ? DateTime.MinValue : reader.GetDateTime("date_expiration"),
                                JoursRestants = reader.IsDBNull(reader.GetOrdinal("jours_restants")) ? 0 : reader.GetInt32("jours_restants"),
                                Fournisseur = reader.IsDBNull(reader.GetOrdinal("fournisseur")) ? "Non spécifié" : reader.GetString("fournisseur"),
                                DateAchat = reader.IsDBNull(reader.GetOrdinal("date_achat")) ? DateTime.MinValue : reader.GetDateTime("date_achat")
                            };
                            liste.Add(medicament);
                        }
                    }
                }
            }

            return liste;
        }
        public static List<Medicament> GetEnStock(string searchTerm = "")
        {
            string query = @"SELECT 
                    m.id,
                    m.nom,
                    m.description,
                    m.prix,
                    l.id AS id_lot,
                    l.quantite_reste AS quantite_restante,
                    l.date_ajout,
                    l.date_expiration,
                    DATEDIFF(l.date_expiration, CURDATE()) AS jours_restants,
                    f.nom AS fournisseur,
                    a.date_achat
                FROM medicament m
                JOIN lots l ON m.id = l.id_medicament
                LEFT JOIN achat a ON l.id_achat = a.id
                LEFT JOIN fournisseur f ON a.id_fournisseur = f.id
                WHERE l.date_expiration >= CURDATE() 
                AND l.quantite_reste > 0
                AND (a.statut IS NULL OR a.statut != 'annulé')
                AND (@searchTerm = '' OR 
                     m.nom LIKE CONCAT('%', @searchTerm, '%') OR 
                     m.description LIKE CONCAT('%', @searchTerm, '%'))
                ORDER BY m.nom, l.date_expiration ASC";

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@searchTerm", searchTerm ?? "")
            };

            return ExecuteMedicamentQuery(query, parameters);
        }

        public static List<Medicament> GetEnRupture(string searchTerm = "")
        {
            string query = @"SELECT 
                m.id, 
                m.nom, 
                m.description,
                m.prix,
                0 as quantite_restante,
                NULL as id_lot,
                NULL as date_ajout,
                NULL as date_expiration,
                0 as jours_restants,
                NULL as fournisseur,
                NULL as date_achat
            FROM medicament m
            WHERE NOT EXISTS (
                SELECT 1 FROM lots l 
                WHERE l.id_medicament = m.id 
                AND l.quantite_reste > 0
                AND l.date_expiration >= CURDATE()
            )
            AND (@searchTerm = '' OR 
                 m.nom LIKE CONCAT('%', @searchTerm, '%') OR 
                 m.description LIKE CONCAT('%', @searchTerm, '%'))
            ORDER BY m.nom";

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@searchTerm", searchTerm ?? "")
            };

            return ExecuteMedicamentQuery(query, parameters);
        }

        // Version avec recherche intégrée
        public static List<Medicament> GetExpires(string searchTerm = "")
        {
            string query = @"SELECT 
            m.id,
            m.nom,
            m.description,
            m.prix,
            l.id AS id_lot,
            l.quantite_reste AS quantite_restante,
            l.date_ajout,
            l.date_expiration,
            DATEDIFF(l.date_expiration, CURDATE()) AS jours_restants,
            f.nom AS fournisseur,
            a.date_achat
        FROM medicament m
        JOIN lots l ON m.id = l.id_medicament
        LEFT JOIN achat a ON l.id_achat = a.id
        LEFT JOIN fournisseur f ON a.id_fournisseur = f.id
        WHERE l.date_expiration < CURDATE()
        AND l.quantite_reste > 0
        AND (a.statut IS NULL OR a.statut != 'annulé')
        AND (@searchTerm = '' OR 
             m.nom LIKE CONCAT('%', @searchTerm, '%') OR 
             m.description LIKE CONCAT('%', @searchTerm, '%'))
        ORDER BY m.nom, l.date_expiration ASC";

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@searchTerm", searchTerm ?? "")
            };

            return ExecuteMedicamentQuery(query, parameters);
        }

        public static List<Medicament> Search(string searchTerm = "")
        {
            string query = @"SELECT 
            m.id,
            m.nom,
            m.description,
            m.prix,
            l.id AS id_lot,
            l.quantite_reste AS quantite_restante,
            l.date_ajout,
            l.date_expiration,
            DATEDIFF(l.date_expiration, CURDATE()) AS jours_restants,
            f.nom AS fournisseur,
            a.date_achat
        FROM medicament m
        LEFT JOIN lots l ON m.id = l.id_medicament
        LEFT JOIN achat a ON l.id_achat = a.id
        LEFT JOIN fournisseur f ON a.id_fournisseur = f.id
        WHERE (@searchTerm = '' OR 
             m.nom LIKE CONCAT('%', @searchTerm, '%') OR 
             m.description LIKE CONCAT('%', @searchTerm, '%'))
        AND (a.statut IS NULL OR a.statut != 'annulé')
        ORDER BY m.nom, l.date_expiration ASC";

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@searchTerm", searchTerm ?? "")
            };

            return ExecuteMedicamentQuery(query, parameters);
        }

        public static List<Medicament> GetExpires()
        {
            return GetPresqueExpires(0); // 0 jours restants = déjà expirés
        }

        public static bool Add(Medicament medicament)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO medicament (nom, description, prix) 
                        VALUES (@nom, @description, @prix)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", medicament.Nom);
                    cmd.Parameters.AddWithValue("@description",
                        string.IsNullOrEmpty(medicament.Description) ? DBNull.Value : (object)medicament.Description);
                    cmd.Parameters.AddWithValue("@prix", medicament.Prix);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static Medicament GetById(int id)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                id,
                nom,
                description,
                prix
            FROM medicament
            WHERE id = @id
            LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var medicament = new Medicament
                            {
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Description = reader.IsDBNull(reader.GetOrdinal("description")) ?
                                              null : reader.GetString("description"),
                                Prix = reader.GetDecimal("prix")
                            };

                            // Charger les lots associés
                            medicament.Lots = GetLotsByMedicament(medicament.Id);

                            return medicament;
                        }
                    }
                }
            }
            return null;
        }

        public static bool Update(Medicament medicament)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE medicament 
                        SET nom = @nom, 
                            description = @description,
                            prix = @prix
                        WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", medicament.Nom);
                    cmd.Parameters.AddWithValue("@description",
                        string.IsNullOrEmpty(medicament.Description) ? DBNull.Value : (object)medicament.Description);
                    cmd.Parameters.AddWithValue("@prix", medicament.Prix);
                    cmd.Parameters.AddWithValue("@id", medicament.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public static bool DeleteLot(int idLot)
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
        public static bool Delete(int id)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM MEDICAMENT WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

       
        public static List<Medicament> GetPresqueExpires(int joursRestants = 30)
        {
            var liste = new List<Medicament>();

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT 
                        m.id, 
                        m.nom, 
                        m.description,
                        m.prix,
                        l.id as id_lot,
                        l.quantite_reste,
                        l.date_expiration,
                        DATEDIFF(l.date_expiration, CURDATE()) as jours_restants,
                        f.nom as fournisseur
                    FROM medicament m
                    JOIN lots l ON m.id = l.id_medicament
                    LEFT JOIN achat a ON l.id_achat = a.id
                    LEFT JOIN fournisseur f ON a.id_fournisseur = f.id
                    WHERE l.date_expiration BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL @joursRestants DAY)
                    AND l.quantite_reste > 0
                    AND (a.statut IS NULL OR a.statut != 'annulé')
                    ORDER BY l.date_expiration ASC";

                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@joursRestants", joursRestants);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new Medicament
                        {
                            Id = reader.GetInt32("id"),
                            Nom = reader.GetString("nom"),
                            Description = reader.IsDBNull(reader.GetOrdinal("description")) ?
                                        string.Empty :
                                        reader.GetString("description"),
                            Prix = reader.GetDecimal("prix"),
                            IdLot = reader.GetDecimal("id_lot"),
                            QuantiteRestante = reader.GetInt32("quantite_reste"),
                            DateExpiration = reader.GetDateTime("date_expiration"), // Garanti non-null par WHERE
                            JoursRestants = reader.GetInt32("jours_restants"),
                            Fournisseur = reader.IsDBNull(reader.GetOrdinal("fournisseur")) ?
                                        "Inconnu" :
                                        reader.GetString("fournisseur")
                        });
                    }
                }
            }

            return liste;
        }

        public static List<Medicament> GetAll()
        {
            string query = @"SELECT 
                    id,
                    nom,
                    description,
                    prix
                FROM medicament
                ORDER BY nom ASC";

            return ExecuteSimpleMedicamentQuery(query);
        }
        private static List<Medicament> ExecuteSimpleMedicamentQuery(string query, MySqlParameter[] parameters = null)
        {
            var liste = new List<Medicament>();

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new Medicament
                            {
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Description = reader.IsDBNull(reader.GetOrdinal("description")) ?
                                            null : reader.GetString("description"),
                                Prix = reader.GetDecimal("prix")
                                // Les autres propriétés restent à leurs valeurs par défaut
                            });
                        }
                    }
                }
            }
            return liste;
        }
        public static List<Medicament> GetAllInStock()
        {
            List<Medicament> medicaments = new List<Medicament>();

            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT m.id, m.nom, m.prix, 
                        COALESCE(SUM(l.quantite_reste), 0) AS quantite_disponible
                        FROM medicament m
                        LEFT JOIN lots l ON m.id = l.id_medicament
                        WHERE l.quantite_reste > 0
                        AND l.date_expiration >= CURDATE()
                        GROUP BY m.id, m.nom, m.prix
                        HAVING quantite_disponible > 0
                        ORDER BY m.nom";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var medicament = new Medicament
                            {
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Prix = reader.GetDecimal("prix"),
                                QuantiteRestante = reader.GetInt32("quantite_disponible")
                            };

                            // Optionnel : charger les lots si nécessaire
                            // medicament.Lots = GetLotsByMedicament(medicament.Id);

                            medicaments.Add(medicament);
                        }
                    }
                }
            }

            return medicaments;
        }
        public static int GetStockDisponible(int idMedicament)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT COALESCE(SUM(quantite_reste), 0) as stock_disponible
                    FROM lots
                    WHERE id_medicament = @idMedicament
                    AND quantite_reste > 0
                    AND date_expiration >= CURDATE()";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idMedicament", idMedicament);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32("stock_disponible");
                        }
                    }
                }
            }
            return 0;
        }
        public static List<Lot> GetLotsByMedicament(int idMedicament)
        {
            var lots = new List<Lot>();

            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT id, id_medicament, quantite_total, quantite_reste, date_expiration
                        FROM lots
                        WHERE id_medicament = @idMedicament
                        AND quantite_reste > 0
                        AND date_expiration >= CURDATE()
                        ORDER BY date_expiration ASC";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idMedicament", idMedicament);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lots.Add(new Lot
                            {
                                Id = reader.GetInt32("id"),
                                IdMedicament = reader.GetInt32("id_medicament"),
                                QuantiteTotal = reader.GetInt32("quantite_total"),
                                QuantiteRestante = reader.GetInt32("quantite_reste"),
                                DateExpiration = reader.GetDateTime("date_expiration")
                            });
                        }
                    }
                }
            }

            return lots;
        }
        public static bool DeduireStockParLot(int idMedicament, int quantite)
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Récupérer les lots triés par date d'expiration (les plus proches en premier)
                        string queryLots = @"SELECT id, quantite_reste 
                            FROM lots 
                            WHERE id_medicament = @idMedicament 
                            AND quantite_reste > 0
                            AND date_expiration >= CURDATE()
                            ORDER BY date_expiration ASC";

                        var lots = new List<(int id, int quantiteRestante)>(); // Changé le nom de la variable

                        using (var cmd = new MySqlCommand(queryLots, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@idMedicament", idMedicament);
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    lots.Add((reader.GetInt32("id"), reader.GetInt32("quantite_reste")));
                                }
                            }
                        }

                        int quantiteRestanteADeduire = quantite;

                        foreach (var lot in lots)
                        {
                            if (quantiteRestanteADeduire <= 0) break;

                            int quantiteADeduire = Math.Min(quantiteRestanteADeduire, lot.quantiteRestante); // Utilisé le nouveau nom

                            string updateQuery = @"UPDATE lots 
                                 SET quantite_reste = quantite_reste - @quantite 
                                 WHERE id = @idLot";

                            using (var cmd = new MySqlCommand(updateQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@quantite", quantiteADeduire);
                                cmd.Parameters.AddWithValue("@idLot", lot.id);
                                cmd.ExecuteNonQuery();
                            }

                            quantiteRestanteADeduire -= quantiteADeduire;
                        }

                        if (quantiteRestanteADeduire > 0)
                        {
                            throw new Exception($"Stock insuffisant pour le médicament ID {idMedicament}. Il manque {quantiteRestanteADeduire} unités.");
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
        public static int CreerVente(MySqlTransaction transaction, Vente vente, List<DetailVente> details)
        {
            // 1. Enregistrer la vente
            string queryVente = @"INSERT INTO vente (id_client, id_utilisateur, total, date_vente) 
                         VALUES (@idClient, @idUtilisateur, @total, @dateVente);
                         SELECT LAST_INSERT_ID();";

            int idVente;
            using (var cmd = new MySqlCommand(queryVente, transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idClient", vente.IdClient);
                cmd.Parameters.AddWithValue("@idUtilisateur", vente.IdUtilisateur);
                cmd.Parameters.AddWithValue("@total", vente.Total);
                cmd.Parameters.AddWithValue("@dateVente", vente.DateVente);

                idVente = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // 2. Enregistrer les détails de vente et mettre à jour les stocks
            foreach (var detail in details)
            {
                // Enregistrer le détail de vente
                string queryDetail = @"INSERT INTO detailvente (id_vente, id_medicament, quantite, prix_unitaire) 
                              VALUES (@idVente, @idMedicament, @quantite, @prixUnitaire)";

                using (var cmd = new MySqlCommand(queryDetail, transaction.Connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@idVente", idVente);
                    cmd.Parameters.AddWithValue("@idMedicament", detail.IdMedicament);
                    cmd.Parameters.AddWithValue("@quantite", detail.Quantite);
                    cmd.Parameters.AddWithValue("@prixUnitaire", detail.PrixUnitaire);

                    cmd.ExecuteNonQuery();
                }

                // Mettre à jour les lots utilisés
                foreach (var lotUtilise in detail.LotsUtilises)
                {
                    string queryLot = @"UPDATE lots 
                              SET quantite_reste = quantite_reste - @quantiteDeduite 
                              WHERE id = @idLot";

                    using (var cmd = new MySqlCommand(queryLot, transaction.Connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@idLot", lotUtilise.IdLot);
                        cmd.Parameters.AddWithValue("@quantiteDeduite", lotUtilise.QuantiteDeduite);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            return idVente;
        }
    }
}
