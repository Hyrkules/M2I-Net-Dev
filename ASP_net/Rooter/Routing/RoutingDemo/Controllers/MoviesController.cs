using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    /*
     Système gestion de films avec le routing par attributs.
     */

    [Route("Movies")]
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
