using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoutingDemo.Controllers
{
    /// <summary>
    /// Créer un système de gestion de bibliothèque avec le routing conventionnel.
    /// 
    /// Liste de tous les livres : /Book
    /// Details d'un livre par son identifiant : /Book/Details/5
    /// Livres par genre : /Book/Genre/Fantasy
    /// Recherche avec pagination : /Book/Search?title=potter&page=2
    /// 
    /// Créer une route personnalisée pour les nouveautés : /nouveautes/{year}/{month}
    /// </summary>
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return Content("Liste de tous les livres");
        }

        public IActionResult Details(int id)
        {
            return Content($"Détails du livre avec l'id #{id}");
        }

        public IActionResult Genre(string genre)
        {
            return Content($"Détails du livre avec le genre : {genre}");
        }

        public IActionResult Search(string title, int page)
        {
            return Content($"Recherche du livre {title}, à la page {page}");
        }

        public IActionResult Nouveautes(int year, int month)
        {
            return Content($"Nouveautés de {month} / {year}");
        }

    }
}
