using System;
using System.Collections.Generic;
using System.Text;

namespace TPRecipe.Classes
{
    internal class RecetteIngredient
    {
        public int Id { get; set; }
        public int RecetteId { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public string Quantite { get; set; }
        public int Ordre { get; set; }
    }
}
