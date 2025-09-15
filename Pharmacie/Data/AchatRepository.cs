using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Pharmacie.Models;

namespace Pharmacie.Data
{
    public class AchatRepository
    {
        public static int CreateAchat(Achat achat)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO achat 
                               (id_fournisseur, id_utilisateur, date_achat, total, statut) 
                               VALUES (@idFournisseur, @idUtilisateur, @dateAchat, @total, @statut);
                               SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idFournisseur", achat.IdFournisseur);
                    cmd.Parameters.AddWithValue("@idUtilisateur", achat.IdUtilisateur);
                    cmd.Parameters.AddWithValue("@dateAchat", DateTime.Now);
                    cmd.Parameters.AddWithValue("@total", achat.Total);
                    cmd.Parameters.AddWithValue("@statut", achat.Statut);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static bool AddLot(int idAchat, LotAchat lot)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO lots 
                               (id_medicament, id_achat, quantite_total, quantite_reste, 
                                date_ajout, date_expiration) 
                               VALUES (@idMedicament, @idAchat, @quantiteTotal, @quantiteRestante, 
                                       @dateAjout, @dateExpiration)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idMedicament", lot.IdMedicament);
                    cmd.Parameters.AddWithValue("@idAchat", idAchat);
                    cmd.Parameters.AddWithValue("@quantiteTotal", lot.Quantite);
                    cmd.Parameters.AddWithValue("@quantiteRestante", lot.Quantite);
                    cmd.Parameters.AddWithValue("@dateAjout", DateTime.Now);
                    cmd.Parameters.AddWithValue("@dateExpiration", lot.DateExpiration);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateStatut(int idAchat, string statut, bool setDateAjout = false)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = setDateAjout
                    ? "UPDATE achat SET statut = @statut WHERE id = @idAchat; UPDATE lots SET date_ajout = NOW() WHERE id_achat = @idAchat;"
                    : "UPDATE achat SET statut = @statut WHERE id = @idAchat";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@statut", statut);
                    cmd.Parameters.AddWithValue("@idAchat", idAchat);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
