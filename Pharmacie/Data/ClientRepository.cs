using MySql.Data.MySqlClient;
using Pharmacie.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacie.Data
{
    public static class ClientRepository
    {
        public static List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();

            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT id, nom, telephone, email, adresse FROM client ORDER BY nom";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client
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

            return clients;
        }

        public static Client GetById(int id)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM client WHERE id = @id LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Client
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

        public static bool Add(Client client)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO client (nom, telephone, email, adresse) 
                                VALUES (@nom, @telephone, @email, @adresse)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", client.Nom);
                    cmd.Parameters.AddWithValue("@telephone", string.IsNullOrEmpty(client.Telephone) ? DBNull.Value : (object)client.Telephone);
                    cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(client.Email) ? DBNull.Value : (object)client.Email);
                    cmd.Parameters.AddWithValue("@adresse", string.IsNullOrEmpty(client.Adresse) ? DBNull.Value : (object)client.Adresse);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Update(Client client)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE client 
                                SET nom = @nom, 
                                    telephone = @telephone,
                                    email = @email,
                                    adresse = @adresse
                                WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nom", client.Nom);
                    cmd.Parameters.AddWithValue("@telephone", string.IsNullOrEmpty(client.Telephone) ? DBNull.Value : (object)client.Telephone);
                    cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(client.Email) ? DBNull.Value : (object)client.Email);
                    cmd.Parameters.AddWithValue("@adresse", string.IsNullOrEmpty(client.Adresse) ? DBNull.Value : (object)client.Adresse);
                    cmd.Parameters.AddWithValue("@id", client.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool Delete(int id)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM client WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Client> Search(string searchTerm)
        {
            List<Client> clients = new List<Client>();

            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT * FROM client 
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
                            clients.Add(new Client
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

            return clients;
        }
    }
}
