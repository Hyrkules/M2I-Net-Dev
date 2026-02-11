using Microsoft.AspNetCore.Mvc;

namespace View_Models_en_details.Models
{
    public class Categorie : Controller
    {
        public int CategorieId { get; set; }
        public string Nom { get; set; } = string.Empty;

        public IActionResult Index()
        {
            return View();
        }
    }
}
