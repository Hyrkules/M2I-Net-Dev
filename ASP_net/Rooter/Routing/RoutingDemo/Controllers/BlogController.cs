using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return Content("Liste des articles du blog");
        }

        public IActionResult Article(int year, int month, string slug)
        {
            return Content($"Article du blog - Année: {year}, Mois: {month}, Slug: {slug}");
        }
    }
}
