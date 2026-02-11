using Microsoft.AspNetCore.Mvc;
using ViewExercice.Models;

namespace ViewExercice.Controllers
{
    public class EtudiantController : Controller
    {
        //Creer un controller pour les notes ?
        public IActionResult Index()
        {
            ViewData["Title"] = "Etudiants";

            var etudiant = new List<Etudiant>
            {
                new Etudiant
                {
                    Id=1,
                    Nom="Jean",
                    Prenom="Jean",
                    Note=15,
                },
                new Etudiant
                {
                    Id=2,
                    Nom="Pierre",
                    Prenom="Pierre",
                    Note=5,
                },
                new Etudiant
                {
                    Id=3,
                    Nom="Test",
                    Prenom="Test",
                    Note=20,
                },
                new Etudiant
                {
                    Id=4,
                    Nom="Autre",
                    Prenom="Autre",
                    Note=16,
                },
                new Etudiant
                {
                    Id=5,
                    Nom="Machin",
                    Prenom="Machin",
                    Note=11,
                }
            };

            return View(etudiant);
        }
    }
}
