using System;
using System.Collections.Generic;
using System.Text;

namespace SQL_Csharp.Classes
{
    internal class Etudiant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Classe { get; set; }
        public string DateDiplome { get; set; }

        public Etudiant()
        {

        }

        public Etudiant(string nom, string prenom, int classe, string date)
        {
            Nom = nom;
            Prenom = prenom;
            Classe = classe;
            DateDiplome = date;

        }

        public Etudiant(int id, string nom, string prenom, int classe, string date) : this (nom, prenom, classe, date)
        {
            Id = id;

        }

        public override string ToString()
        {
            return $"Id : {Id} , {Prenom} {Nom} | Classe : {Classe} | DateDiplome : {DateDiplome}";
        }
    }
}
