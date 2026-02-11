using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace ModelDemo.ViewModel
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Veuillez entrer votre nom")]
        [Display(Name = "Votre nom")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre 2 et 50 caractères")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Veuillez entrer votre email")]
        [Display(Name = "Votre email", Prompt ="email@email.com")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Veuillez entrer un sujet")]
        [Display(Name = "Sujet du message")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Le sujet doit contenir entre 5 et 100 caractères")]
        public string Sujet { get; set; }

        [Required(ErrorMessage = "Veuillez entrer votre message")]
        [Display(Name = "Votre message")]
        [StringLength(2000, MinimumLength = 20, ErrorMessage = "Le message doit contenir entre 20 et 2000 caractères")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [Display(Name = "Téléphone (optionnel)", Prompt ="0606060606")]
        [Phone(ErrorMessage = "Numéro de téléphone invalide")]
        
        public string Phone { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner un niveau d'urgence")]
        [Display(Name = "Niveau d'urgence")]
        public string Urgency { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner un niveau d'urgence")]
        public string UrgencyOptions { get; set; }


    }
}