using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaireApp.Classes
{
    internal class Client
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Identifiant { get; set; }
        public List<CompteBancaire> CompteBancaires { get; set; }
        public string NumTel {  get; set; }

        public Client(string nom, string prenom, string identifiant, string numTel)
        {
            Nom = nom;
            Prenom = prenom;
            Identifiant = identifiant;
            NumTel = numTel;
            CompteBancaires = new List<CompteBancaire>();
        }

        public void AjouterCompte(CompteBancaire compteBancaire)
        {
            CompteBancaires.Add(compteBancaire);
        }
        //public void ListerComptes()
        //{
        //    Console.WriteLine($"Client : {Nom} {Prenom} (ID: {Identifiant}) - Tel: {NumTel}");
        //    if (LstComptes == null || LstComptes.Count == 0)
        //    {
        //        Console.WriteLine("Aucun compte trouvé.");
        //        return;
        //    }

        //    Console.WriteLine("Comptes :");
        //    for (int i = 0; i < LstComptes.Count; i++)
        //    {
        //        Console.WriteLine($"  {i + 1}. {LstComptes[i]}");
        //    }
    
    }

}
