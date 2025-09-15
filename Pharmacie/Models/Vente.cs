using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacie.Models
{
    public class Vente
    {
        public int Id { get; set; }
        public int? IdClient { get; set; }
        public int IdUtilisateur { get; set; }
        public decimal Total { get; set; }
        public DateTime DateVente { get; set; }
        public List<DetailVente> Details { get; set; } = new List<DetailVente>();
    }

}
