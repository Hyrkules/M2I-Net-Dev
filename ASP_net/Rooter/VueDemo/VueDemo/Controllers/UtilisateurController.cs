using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VueDemo.Models;

namespace VueDemo.Controllers
{
    public class UtilisateurController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreerUnUtilisateur() 
        {
            ViewBag.pays = new List<SelectListItem>()
            {
                new SelectListItem{Value="FR", Text="France"},
                new SelectListItem{Value="US", Text="États-Unis"},
                new SelectListItem{Value="UK", Text="Royaume-Uni"},
            };

            return View(new Utilisateur());
        }
    }
}
