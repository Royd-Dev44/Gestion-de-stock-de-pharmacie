using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacie.Models
{
    public class Stock
    {
        public int IdLot { get; set; }
        public int IdAchat { get; set; }
        public int IdMedicament { get; set; }
        public string NomMedicament { get; set; }
        public int QuantiteTotal { get; set; }
        public int QuantiteRestante { get; set; }
        public DateTime DateAjout { get; set; }
        public DateTime DateAchat { get; set; }
        public decimal TotalAchat { get; set; }
        public DateTime DateExpiration { get; set; }
        public int IdUtilisateur { get; set; }
        public string Statut { get; set; }
    }
}
