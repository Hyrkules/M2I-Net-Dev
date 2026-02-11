using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TP_asp.netMVS.ViewModel.Produits
{
    public class ProduitFormViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public int QuantiteStock { get; set; }
        public bool EstEnStock { get; set; }
        public string NomCategorie { get; set; }
        public int CategorieID { get; set; }
        public SelectList? CategoriesSelectList { get; set; }

    }
}
