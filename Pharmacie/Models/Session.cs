using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacie.Models
{
    public static class SessionUtilisateur
    {
        public static int Id { get; set; }
        public static string Nom { get; set; }
        public static string Role { get; set; } 

        public static void Deconnecter()
        {
            Id = 0;
            Nom = null;
            Role = null;
        }
    }
}
