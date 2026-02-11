using System.ComponentModel.DataAnnotations;

namespace View_Models_en_details.ViewModel
{
    public class ProduitDetailsViewModel
    {
        public string Nom { get; set; } = string.Empty;

        [Display(Name = "Prix")]
        public string PrixFormatte { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string NomCategorie { get; set; } = string.Empty;
    }
}