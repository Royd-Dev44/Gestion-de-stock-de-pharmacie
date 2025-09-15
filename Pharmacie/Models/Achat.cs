using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacie.Models
{
    public static class StatutAchat
    {
        public const string EnAttente = "En attente";
        public const string Confirme = "Confirmé";
        public const string Annule = "Annulé";
    }
    public class Achat
    {
        public int? IdAchat { get; set; }
        public int IdFournisseur { get; set; }
        public int IdUtilisateur { get; set; }
        public decimal Total { get; set; }
        public string Statut { get; set; } = StatutAchat.EnAttente;
        public List<LotAchat> Lots { get; set; } = new List<LotAchat>();
    }

    public class LotAchat
    {
        public int IdMedicament { get; set; }
        public string NomMedicament { get; set; }
        public int Quantite { get; set; }
        public DateTime DateExpiration { get; set; }
        public DateTime DateAjout { get; set; } 
        public decimal PrixUnitaire { get; set; }
        public decimal Total => Quantite * PrixUnitaire;
    }
}
