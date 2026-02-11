using Microsoft.AspNetCore.Mvc;
using VueDemo.Models;

namespace VueDemo.Controllers
{
    public class ProduitFormulaireController : Controller
    {
        private static List<Produit> _produits = new List<Produit>();

        private static int _prochainId = 1;

        public IActionResult Index()
        {
            return View(_produits);
        }

        [HttpGet]
        public IActionResult Creer()
        {
            return View(new Produit());
        }

        [HttpPost]
        public IActionResult Creer(Produit produitCree)
        {
            produitCree.Id = _prochainId;
            _prochainId++;
            _produits.Add(produitCree);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var produit = _produits.FirstOrDefault(i=>i.Id==id);
            return View(produit);
        }
    }
}
