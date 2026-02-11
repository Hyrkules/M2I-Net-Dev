using System;
using System.Collections.Generic;
using System.Text;

namespace TPRecipe.Classes
{
    internal class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Ingredient()
        {
        }
        public Ingredient(string name)
        {
            Name = name;
        }

        public Ingredient(int id,string name) : this(name)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"Name : {Name}";
        }
    }
}
