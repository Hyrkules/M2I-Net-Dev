using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBilletsEvent.Classes
{
    public class Evenement
    {
        public string Nom { get; }
        public DateTime Date { get; }
        public Lieu Lieu { get; }
        public List<Billet> Billets { get; }

        public Evenement(string nom, DateTime date, Lieu lieu)
        {
            Nom = nom;
            Date = date;
            Lieu = lieu;
            Billets = new List<Billet>();
        }

        public void AfficherListeBillets()
        {
            foreach (var billet in Billets)
            {
                    Console.WriteLine(billet.Evenement.Nom + " | " + billet.Evenement.Date + " | " + billet.Evenement.Lieu.Ville + " | " + billet.TypePlace);
            }
        }
    }
}
