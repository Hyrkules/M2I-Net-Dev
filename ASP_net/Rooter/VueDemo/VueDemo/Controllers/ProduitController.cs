using Microsoft.AspNetCore.Mvc;
using VueDemo.Models;

namespace VueDemo.Controllers
{
    public class ProduitController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Nos Produits";
            //var produit = new Produit()
            //{
            //    Id = 1,
            //    Nom = "Ordinateur Portable",
            //    Prix = 999.99m,
            //    QuantiteEnStock = 50
            //};

            var produit = new List<Produit>
            {
                new Produit
                {
                    Id=1,
                    Nom="Ordinateur",
                    Prix=500.25m,
                    QuantiteEnStock = 10
                },
                new Produit
                {
                    Id=2,
                    Nom="Clavier",
                    Prix=50.25m,
                    QuantiteEnStock = 5
                },
                new Produit
                {
                    Id=3,
                    Nom="Souris",
                    Prix=10.25m,
                    QuantiteEnStock = 20
                }
            };

            return View(produit);
        }

        public IActionResult Details()
        {
            return Content("Page de détail");
        }

        public IActionResult DetailsAvecParams(int id)
        {
            return Content($"Infos avec id {id}");
        }

        public IActionResult Liste(string categorie, string sort)
        {
            return Content($"Page liste pdt Electronique");
        }
    }
}
