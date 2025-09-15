using MySql.Data.MySqlClient;
using Pharmacie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacie.Data
{
    public static class UtilisateurRepository
    {
        public static List<Utilisateur> GetAll()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id, nom, telephone, email, adresse, role, date_creation FROM utilisateur ORDER BY nom";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            utilisateurs.Add(new Utilisateur
                            {
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? null : reader.GetString("telephone"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                Adresse = reader.IsDBNull(reader.GetOrdinal("adresse")) ? null : reader.GetString("adresse"),
                                Role = reader.GetString("role"),
                                DateCreation = reader.GetDateTime("date_creation")
                            });
                        }
                    }
                }
            }

            return utilisateurs;
        }

        public static Utilisateur GetById(int id)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM utilisateur WHERE id = @id LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Utilisateur
                            {
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? null : reader.GetString("telephone"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                Adresse = reader.IsDBNull(reader.GetOrdinal("adresse")) ? null : reader.GetString("adresse"),
                                Mdp = reader.GetString("mdp"),
                                Role = reader.GetString("role"),
                                DateCreation = reader.GetDateTime("date_creation")
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool Add(Utilisateur utilisateur)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO utilisateur (nom, telephone, email, adresse, mdp, role, date_creation) 
                                VALUES (@nom, @telephone, @email, @adresse, @mdp, @role, @date_creation)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
                    cmd.Parameters.AddWithValue("@telephone", string.IsNullOrEmpty(utilisateur.Telephone) ? DBNull.Value : (object)utilisateur.Telephone);
                    cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(utilisateur.Email) ? DBNull.Value : (object)utilisateur.Email);
                    cmd.Parameters.AddWithValue("@adresse", string.IsNullOrEmpty(utilisateur.Adresse) ? DBNull.Value : (object)utilisateur.Adresse);
                    cmd.Parameters.AddWithValue("@mdp", utilisateur.Mdp);
                    cmd.Parameters.AddWithValue("@role", utilisateur.Role);
                    cmd.Parameters.AddWithValue("@date_creation", DateTime.Now);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Update(Utilisateur utilisateur)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE utilisateur 
                                SET nom = @nom, 
                                    telephone = @telephone,
                                    email = @email,
                                    adresse = @adresse,
                                    role = @role
                                WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", utilisateur.Nom);
                    cmd.Parameters.AddWithValue("@telephone", string.IsNullOrEmpty(utilisateur.Telephone) ? DBNull.Value : (object)utilisateur.Telephone);
                    cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(utilisateur.Email) ? DBNull.Value : (object)utilisateur.Email);
                    cmd.Parameters.AddWithValue("@adresse", string.IsNullOrEmpty(utilisateur.Adresse) ? DBNull.Value : (object)utilisateur.Adresse);
                    cmd.Parameters.AddWithValue("@role", utilisateur.Role);
                    cmd.Parameters.AddWithValue("@id", utilisateur.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Delete(int id)
        {
            // Empêcher un utilisateur de se supprimer lui-même
            if (id == SessionUtilisateur.Id)
            {
                MessageBox.Show("Vous ne pouvez pas supprimer votre propre compte.",
                              "Opération non autorisée",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return false;
            }

            // Vérifier que seul un admin peut supprimer
            if (SessionUtilisateur.Role != "admin")
            {
                MessageBox.Show("Seuls les administrateurs peuvent supprimer des utilisateurs.",
                              "Permission refusée",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return false;
            }
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM utilisateur WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Utilisateur> Search(string searchTerm)
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT * FROM utilisateur 
                        WHERE nom LIKE @searchTerm
                        OR telephone LIKE @searchTerm
                        OR email LIKE @searchTerm
                        OR adresse LIKE @searchTerm
                        OR role LIKE @searchTerm
                        ORDER BY nom ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            utilisateurs.Add(new Utilisateur
                            {
                                Id = reader.GetInt32("id"),
                                Nom = reader.GetString("nom"),
                                Telephone = reader.IsDBNull(reader.GetOrdinal("telephone")) ? null : reader.GetString("telephone"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                Adresse = reader.IsDBNull(reader.GetOrdinal("adresse")) ? null : reader.GetString("adresse"),
                                Role = reader.GetString("role"),
                                DateCreation = reader.GetDateTime("date_creation")
                            });
                        }
                    }
                }
            }

            return utilisateurs;
        }

    }
}
