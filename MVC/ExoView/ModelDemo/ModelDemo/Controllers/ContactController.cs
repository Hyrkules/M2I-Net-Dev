using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelDemo.Models;
using ModelDemo.ViewModel;

namespace ModelDemo.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.urgencyOptions = new List<SelectListItem>()
            {
                new SelectListItem{Value="low", Text="Basse"},
                new SelectListItem{Value="medium", Text="Normale"},
                new SelectListItem{Value="high", Text="Haute"},
            };

            return View(new Formulaire());
        }
        [HttpPost]
        public IActionResult Create(Formulaire model)
        {
            if (!ModelState.IsValid)
            {
                // Traitement du formulaire
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
