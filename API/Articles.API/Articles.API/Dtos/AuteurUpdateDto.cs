using System.ComponentModel.DataAnnotations;

namespace Articles.API.Dtos
{
    public class AuteurUpdateDto
    {
        [Required]
        public string Nom { get; set; } = string.Empty;
        [Required]
        public string Prenom { get; set; } = string.Empty;
    }
}
