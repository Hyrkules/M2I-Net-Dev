using System;
using System.Collections.Generic;
using System.Text;

namespace TPRecipe.Classes
{
    internal class Etape
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Etape()
        {
        }
        public Etape(string description, int numero)
        {
            Description = description;
        }
        public Etape(int id, string description, int numero) : this(description, numero)
        {
            Id = id;
        }
        public override string ToString()
        {
            return $"Id : {Id} | Description : {Description}";
        }
    }
}
