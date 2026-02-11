using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBilletsEvent.Classes
{
    public class Lieu : Adresse
    {
        public int capacite { get; set; }
        public Lieu(string rue, string ville, int capacite) : base(rue, ville)
        {
        }
    }
}
