using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacie.Models
{
    public class Fournisseur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }

        public override string ToString()
        {
            return Nom;
        }
    }
}
