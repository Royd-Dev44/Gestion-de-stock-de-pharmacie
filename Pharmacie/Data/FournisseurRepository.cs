using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Pharmacie.Models;

namespace Pharmacie.Data
{
    public static class FournisseurRepository
    {
        public static List<Fournisseur> GetAll()
        {
            List<Fournisseur> fournisseurs = new List<Fournisseur>();

            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id, nom, telephone, email, adresse FROM fournisseur ORDER BY nom";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fournisseurs.Add(new Fournisseur
                            {
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ?
                                          null : reader.GetString("telephone"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ?
                                       null : reader.GetString("email"),
                                Adresse = reader.IsDBNull(reader.GetOrdinal("adresse")) ?
                                         null : reader.GetString("adresse")
                            });
                        }
                    }
                }
            }

            return fournisseurs;
        }

        public static Fournisseur GetById(int id)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM fournisseur WHERE id = @id LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Fournisseur
                            {
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? null : reader.GetString("telephone"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                Adresse = reader.IsDBNull(reader.GetOrdinal("adresse")) ? null : reader.GetString("adresse")
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool Add(Fournisseur fournisseur)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO fournisseur (nom, telephone, email, adresse) 
                                VALUES (@nom, @telephone, @email, @adresse)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", fournisseur.Nom);
                    cmd.Parameters.AddWithValue("@telephone", string.IsNullOrEmpty(fournisseur.Telephone) ? DBNull.Value : (object)fournisseur.Telephone);
                    cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(fournisseur.Email) ? DBNull.Value : (object)fournisseur.Email);
                    cmd.Parameters.AddWithValue("@adresse", string.IsNullOrEmpty(fournisseur.Adresse) ? DBNull.Value : (object)fournisseur.Adresse);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Update(Fournisseur fournisseur)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE fournisseur 
                                SET nom = @nom, 
                                    telephone = @telephone,
                                    email = @email,
                                    adresse = @adresse
                                WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", fournisseur.Nom);
                    cmd.Parameters.AddWithValue("@telephone", string.IsNullOrEmpty(fournisseur.Telephone) ? DBNull.Value : (object)fournisseur.Telephone);
                    cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(fournisseur.Email) ? DBNull.Value : (object)fournisseur.Email);
                    cmd.Parameters.AddWithValue("@adresse", string.IsNullOrEmpty(fournisseur.Adresse) ? DBNull.Value : (object)fournisseur.Adresse);
                    cmd.Parameters.AddWithValue("@id", fournisseur.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Delete(int id)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM fournisseur WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public static List<Fournisseur> Search(string searchTerm)
        {
            List<Fournisseur> fournisseurs = new List<Fournisseur>();

            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT * FROM fournisseur 
                        WHERE nom LIKE @searchTerm
                        OR telephone LIKE @searchTerm
                        OR email LIKE @searchTerm
                        OR adresse LIKE @searchTerm
                        ORDER BY nom ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fournisseurs.Add(new Fournisseur
                            {
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? null : reader.GetString("telephone"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                Adresse = reader.IsDBNull(reader.GetOrdinal("adresse")) ? null : reader.GetString("adresse")
                            });
                        }
                    }
                }
            }

            return fournisseurs;
        }
    }
}
