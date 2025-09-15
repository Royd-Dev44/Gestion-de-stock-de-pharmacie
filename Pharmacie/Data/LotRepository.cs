using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacie.Data
{
    public static class LotRepository
    {
        public static void DeduireQuantite(MySqlTransaction transaction, int idLot, int quantite)
        {
            string query = @"UPDATE lots 
                    SET quantite_reste = quantite_reste - @quantite 
                    WHERE id = @idLot AND quantite_reste >= @quantite";

            using (var cmd = new MySqlCommand(query, transaction.Connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idLot", idLot);
                cmd.Parameters.AddWithValue("@quantite", quantite);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("Échec de la déduction du stock. Quantité insuffisante ou lot introuvable.");
                }
            }
        }
    }
}
