using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TPRecipe.Classes
{
    internal class Recette
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int TempsPrep { get; set; }
        public int TempsCuisson { get; set; }
        public int Difficulte { get; set; }
        public List<RecetteIngredient> Ingredients { get; set; } = new();
        public string Etapes { get; set; }
        public string Commentaires { get; set; }
        public string Categorie { get; set; }

        public Recette()
        {
        }

        public override string ToString()
        {
            var ing = string.Join(", ", Ingredients.Select(i => $"{i.Ingredient?.Name}{(string.IsNullOrEmpty(i.Quantite) ? "" : $" ({i.Quantite})")}"));
            return $"Id : {Id} | Nom : {Nom} | TempsPrep : {TempsPrep} | TempsCuisson : {TempsCuisson} | Difficulte : {Difficulte} | Ingrédients : {ing} | Étapes : {Etapes} | Commentaires : {Commentaires} | Catégorie : {Categorie}";
        }
    }
}
