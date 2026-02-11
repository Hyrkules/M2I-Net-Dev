using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBilletsEvent.Classes
{
    public class Client
    {
        public string Nom { get; }
        public string Prenom { get; }
        public string Adresse { get; }
        public int Age { get; }
        public int NumeroTelephone { get; }
        public List<Billet> Billets { get; }

        public Client(string nom, string prenom, string adresse, int age, int numeroTelephone)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Age = age;
            NumeroTelephone = numeroTelephone;
            Billets = new List<Billet>();
        }

        public void ReserverBillet(Billet billet)
        {
            Billets.Add(billet);
        }
    }
}
