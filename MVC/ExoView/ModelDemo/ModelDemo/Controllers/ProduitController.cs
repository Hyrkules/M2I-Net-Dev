using Microsoft.AspNetCore.Mvc;
using ModelDemo.Models;

namespace ModelDemo.Controllers
{
    public class ProduitController : Controller
    {

        

        public IActionResult Index()
        {
            var product = new List<Produit>
            {
                new Produit
                {
                    Id=1,
                    Name="Ordinateur",
                    Prix=500.25m,
                    Stock = 10
                },
                new Produit
                {
                    Id=2,
                    Name="Clavier",
                    Prix=50.25m,
                    Stock = 5
                },
                new Produit
                {
                    Id=3,
                    Name="Souris",
                    Prix=10.25m,
                    Stock = 20
                }
            };
            return View(product);
        }

        public IActionResult Details(int id)
        {
            return Content("Page de détail");
        }
    }
}
