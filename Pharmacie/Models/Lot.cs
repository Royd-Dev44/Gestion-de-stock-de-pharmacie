using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacie.Models
{
    public class Lot
    {
        public int Id { get; set; }
        public int IdMedicament { get; set; }
        public int IdAchat { get; set; }
        public int QuantiteTotal { get; set; }
        public int QuantiteRestante { get; set; } // Notez le nom correct
        public DateTime DateAjout { get; set; }
        public DateTime DateExpiration { get; set; }
    }
}
