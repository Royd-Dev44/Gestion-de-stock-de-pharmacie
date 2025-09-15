using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacie.Models
{
    public class DetailVente
    {
        public int Id { get; set; }
        public int IdVente { get; set; }
        public int IdMedicament { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }
        public List<LotUtilise> LotsUtilises { get; set; } = new List<LotUtilise>();

    }
    public class LotUtilise
    {
        public int IdLot { get; set; }
        public int QuantiteDeduite { get; set; }
    }
}
