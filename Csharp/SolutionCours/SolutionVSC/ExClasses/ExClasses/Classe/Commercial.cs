//using CorrectionExoSalarie.Classes;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ExClasses.Classe
//{
//    internal class Commercial : Salarie
//    {
//        public int ChiffreAffaire { get; set; }
//        public int Commission { get; set; }

//        public Commercial(string matricule, string service, string categorie, string nom, double salaire) : base(matricule, service, categorie, nom, salaire)
//        {
//            ChiffreAffaire = chiffreAffaire;
//            Commission = commission;
//        }

//        public override string AfficherSalaire()
//        {
//            return $"Le salaire de {nom} est de {Salaire + (ChiffreAffaire * (Commission/100))} euros "
//        }

//        public override string ToString()
//        {
//            return base.ToString();
//        }
//    }
//}
