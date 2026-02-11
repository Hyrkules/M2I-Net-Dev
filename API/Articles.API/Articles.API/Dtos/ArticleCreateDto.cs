using System.ComponentModel.DataAnnotations;

namespace Articles.API.Dtos
{
    public class ArticleCreateDto
    {
        [Required(ErrorMessage = "Le titre est obligatoire")]
        public string Titre { get; set; } = string.Empty;
        [Required]
        [MinLength(50, ErrorMessage = "50 caractères")]
        public string Contenu { get; set; } = string.Empty;
        [Required]
        public int AuteurId { get; set; }

    }
}
