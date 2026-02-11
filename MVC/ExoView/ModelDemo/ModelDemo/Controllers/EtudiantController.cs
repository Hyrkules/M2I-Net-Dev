using Microsoft.AspNetCore.Mvc;
using ModelDemo.Models;
using ModelDemo.ViewModel;
using System.Net.Cache;

namespace ModelDemo.Controllers
{
    public class EtudiantController : Controller
    {
        public static List<Etudiant> _etudiants = new List<Etudiant>()
        {
            new Etudiant {Id=1, Nom="Test", Prenom="Test", DateDeNaissance=new DateTime(1987,07,21), Age=38 }
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Inscription()
        {
            return View(new EtudiantInscriptionViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Protection CSRF Vérifie que le formulaire vient bien de notre site
        public IActionResult Inscription(EtudiantInscriptionViewModel etudiantCree)
        {
            // Si toute les data annotations ne sont pas satisfaites
            if (!ModelState.IsValid) { 
                //Retourne dans le formulaire avec les donées créés
                // Les tags helpers afficheront automatiquement les messages d'erreurs
                return View(etudiantCree);
            }
            TempData["Success"] = "Inscritption réussi ! Bienvenue !";

            return RedirectToAction("Index");
        }

    }
}
