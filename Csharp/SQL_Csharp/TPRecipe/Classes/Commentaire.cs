using System;
using System.Collections.Generic;
using System.Text;

namespace TPRecipe.Classes
{
    internal class Commentaire
    {
        public int Id { get; set; }
        public string Contenu { get; set; }
        public Commentaire()
        {
        }
        public Commentaire(string contenu)
        {
            Contenu = contenu;
        }
        public Commentaire(int id, string contenu) : this(contenu)
        {
            Id = id;
        }
        public override string ToString()
        {
            return $"Id : {Id} | Contenu : {Contenu}";
        }
    }
}
