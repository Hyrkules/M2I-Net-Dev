using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    public class ProductController : Controller
    {
        //ULR : /Product/Index - Product
        public IActionResult Index()
        {
            return Content("Liste de tous les produits");
        }

        public IActionResult RecupererProduit(int id)
        {
            return Content($"Voici le produit avec l'id #{id}");
        }

        public IActionResult Categorie(string id = "ALL")
        {
            if (id == "ALL") {
                return Content($"Tous nos produits");
            }
            else
            {
                return Content($"Produits de la catégorie : {id}");
            }
        }

        // URL : Product/Search?nom=ordinateur
        public IActionResult Search(string nom)
        {
            return Content($"Recherche : {nom}");
        }

        // URL : Product/SearchAvecId/id?prix=1000
        public IActionResult SearchAvecId(int id, decimal? prix)
        {
            var message = $"Recherche du produit : {id}";
            if (prix.HasValue)
            {
                message += $"(max) {prix} €";
            }
            return Content(message);
        }

        public IActionResult Details(int id, string format, bool IncludeReview)
        {
            return Content($"Produit {id}, format: {format}, reviews : {IncludeReview}");
        }

        /* Route Personnalisée
         Route Spécifique à un besoin, doit toujours se placer avant la route pas défaut
         
         */

    }
}
