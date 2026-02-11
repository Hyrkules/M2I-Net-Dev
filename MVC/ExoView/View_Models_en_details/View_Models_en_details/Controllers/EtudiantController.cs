using Microsoft.AspNetCore.Mvc;
using View_Models_en_details.Models;
using View_Models_en_details.ViewModel;

namespace View_Models_en_details.Controllers
{
    public class EtudiantController : Controller
    {
        private static List<Etudiant> _etudiants = new List<Etudiant>
        {
            new Etudiant
            {
                Id = 1,
                Name = "Jean",
                Prenom = "Truc",
                Address = "123 rue de Lille",
                DateInscription = new DateTime(2020,5,15),
                BirthDate = new DateTime(2000,9,1),
                Email = "JeanTruc@email.com",
                Phone = "0606060606",
                Note = "Tres serieux, quelques absences justifiées.",
                ClasseId = 1,
                Classe = new Classe { ClasseId=1,ClasseName="L3 Info" }
            }
        };
        public IActionResult Index()
        {
            var etudiantsViewmodels = _etudiants.Select(s => new EtudiantListeViewModel
            {
                Id = s.Id,
                NomComplet = $"{s.Name} {s.Prenom}",
                Email = s.Email,
                NomDeLaClasse = s.Classe?.ClasseName ?? "Sans Classe",
                Age = CalculDeLage(s.BirthDate)
            });
            return View(etudiantsViewmodels);
        }

        private int CalculDeLage(DateTime dateNaissance)
        {
            var aujourdhui = DateTime.Now;
            var age = aujourdhui.Year - dateNaissance.Year;
            if (dateNaissance.Date > aujourdhui.AddYears(-age)) age--;
            return age;
        }
    }
}
