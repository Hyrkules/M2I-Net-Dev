using Microsoft.AspNetCore.Mvc;

namespace View_Models_en_details.Models
{
    public class Produit : Controller
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public decimal Prix { get; set; }
        public int Stock { get; set; }
        public int CategorieId { get; set; }
        public Categorie? Categorie { get; set; }

        public IActionResult Index()
        {
            return View();
        }
    }
}
