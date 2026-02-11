using ModelDemo.Validation;
using System.ComponentModel.DataAnnotations;

namespace ModelDemo.ViewModel
{
    // Class model (viewmodel) adaptée à une vue spécifique. Formulaire d'inscription d'un étudiant
    public class EtudiantInscriptionViewModel
    {
        [Required(ErrorMessage ="Le nom est obligatoire")]
        [Display(Name ="Nom de l'étudiant")]
        [StringLength(50, MinimumLength =2, ErrorMessage ="Le nom doit contenir entre 2 et 50 caractères")]
        public string Nom {  get; set; }

        [EmailAddress(ErrorMessage ="L'adresse mail doit être en format XXXX@XXXX.XXX")]
        [Required(ErrorMessage ="Email obligatoire")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [MinimumAge(16, ErrorMessage ="message d'erreur")]
        public DateTime DateNaissance { get; set; }


    }
}
