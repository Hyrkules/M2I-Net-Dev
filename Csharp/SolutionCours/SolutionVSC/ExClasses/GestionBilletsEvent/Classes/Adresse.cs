using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBilletsEvent.Classes
{
    public class Adresse
    {
        public string Rue { get; set; }
        public string Ville { get; set; }

        public Adresse(string rue, string ville)
        {
            Rue = rue;
            Ville = ville;
        }
    }
}
