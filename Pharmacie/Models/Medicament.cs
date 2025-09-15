using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacie.Models
{
    public class Medicament
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int QuantiteRestante { get; set; }
        public decimal Prix { get; set; }
        public decimal IdLot { get; set; }
        public List<Lot> Lots { get; set; } = new List<Lot>();
        public DateTime DateAjout { get; internal set; }
        public DateTime? DateExpiration { get; set; }
        public int JoursRestants { get; set; }
        public string Fournisseur { get; set; }
        public DateTime? DateAchat { get; set; }

    }
}
