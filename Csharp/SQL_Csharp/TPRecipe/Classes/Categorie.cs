using System;
using System.Collections.Generic;
using System.Text;

namespace TPRecipe.Classes
{
    internal class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public Categorie()
        {
        }
        public Categorie(string nom)
        {
            Nom = nom;
        }
        public Categorie(int id, string nom) : this(nom)
        {
            Id = id;
        }
        public override string ToString()
        {
            return $"Id : {Id} | Nom : {Nom}";
        }
    }
}
