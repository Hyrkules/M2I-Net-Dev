using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TP_asp.netMVS.Models;

namespace TP_asp.netMVS.ViewModels.Produits
{
    public class ProduitListItemViewModel
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public int QuantiteStock { get; set; }
        public bool EstEnStock {  get; set; }
        public string NomCategorie { get; set; }
        public string PrixFormate => Prix.ToString("C", new System.Globalization.CultureInfo("fr-FR"));

        public SelectList CategorieSelectList { get; set; }

    }
}
