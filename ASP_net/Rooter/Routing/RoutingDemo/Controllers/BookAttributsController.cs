using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    //Routing par attributs
    [Route("BooksAttributs")]
    public class BookAttributsController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return Content("List de books dans index");
        }
        [Route("Detail/{id}")]
        public IActionResult Details(int id)
        {
            return Content("Nous sommes dans le details de bookattributs grâce au routing par attributs");
        }

        [Route("Categorie/{categorieName}")]

        public IActionResult Categorie(string categorieName)
        {
            return Content($"Livres de la categorie {categorieName}");
        }
    }

}
