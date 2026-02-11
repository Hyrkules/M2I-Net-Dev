using TP_asp.netMVS.Data;
using TP_asp.netMVS.Models;

namespace TP_asp.netMVS.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
        public void Add(Produit produit)
        {
            if (DbFake.Produits.Any()) {
                produit.Id = DbFake.Produits.Max(p => p.Id) +1;
            }
            else
            {
                produit.Id = 1;
            }

            produit.Categorie = GetCategorieById(produit.CategorieID);
            DbFake.Produits.Add(produit);
        }

        public bool Delete(int id)
        {
            var produit = GetById(id);

            if (produit != null)
            {
                DbFake.Produits.Remove(produit);
                return true;
            }
            return false;
        
        }

        public List<Produit> GetAll()
        {
            return DbFake.Produits;
        }

        public List<Categorie> GetAllCategories()
        {
            return DbFake.Categories.ToList();
        }

        public Produit? GetById(int id)
        {
            return DbFake.Produits.FirstOrDefault(p => p.Id == id);
        }

        public Categorie? GetCategorieById(int id)
        {
            return DbFake.Categories.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Produit produit)
        {
            var index = DbFake.Produits.FindIndex(p => p.Id == produit.Id);

            if(index >= 0)
            {
                produit.Categorie = GetCategorieById(produit.CategorieID);
                DbFake.Produits[index] = produit;
            }
        }
    }
}
