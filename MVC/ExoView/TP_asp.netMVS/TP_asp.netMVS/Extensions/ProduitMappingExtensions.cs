using TP_asp.netMVS.Models;
using TP_asp.netMVS.ViewModel.Produits;
using TP_asp.netMVS.ViewModels.Produits;

namespace GestionProduits.Extensions
{
    public static class ProduitMappingExtensions
    {
        public static ProduitFormViewModel ToFormViewModel(this Produit produit)
        {
            return new ProduitFormViewModel
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Description = produit.Description,
                Prix = produit.Prix,
                QuantiteStock = produit.QuantiteStock,
                CategorieID = produit.CategorieID
            };
        }

        public static Produit ToModel(this ProduitFormViewModel viewModel)
        {
            return new Produit
            {
                Id = viewModel.Id,
                Nom = viewModel.Nom,
                Description = viewModel.Description,
                Prix = viewModel.Prix,
                QuantiteStock = viewModel.QuantiteStock,
                CategorieID = viewModel.CategorieID
            };
        }

        public static ProduitDetailsViewModel ToDetails(this Produit produit)
        {
            return new ProduitDetailsViewModel
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Description = produit.Description,
                Prix = produit.Prix,
                QuantiteStock = produit.QuantiteStock,
                DateCreation = produit.DateCreation,
                CategorieID = produit.CategorieID,
                NomCategorie = produit.Categorie?.Nom ?? "Sans catégorie"
            };
        }

        public static ProduitListItemViewModel ToListItem(this Produit produit)
        {
            return new ProduitListItemViewModel
            {
                Id = produit.Id.ToString(),
                Nom = produit.Nom,
                Prix = produit.Prix,
                QuantiteStock = produit.QuantiteStock,
                NomCategorie = produit.Categorie?.Nom ?? "Sans catégorie"
            };
        }
    }
}