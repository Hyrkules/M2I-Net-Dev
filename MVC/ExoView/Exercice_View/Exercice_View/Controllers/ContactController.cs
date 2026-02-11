using Exercice_View.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exercice_View.Controllers
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
            ViewBag.pays = new List<SelectListItem>()
            {
                new SelectListItem{Value="Question", Text="Question"},
                new SelectListItem{Value="Reclamation", Text="Reclamation"},
                new SelectListItem{Value="Suggestion", Text="Suggestion"},
            };

            return View(new ContactForm());
        }
        [HttpPost]
        public IActionResult Create(ContactForm model) { 
            if (ModelState.IsValid)
            {
                // Traitement du formulaire
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
