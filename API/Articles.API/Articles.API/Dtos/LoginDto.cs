using System.ComponentModel.DataAnnotations;

namespace Articles.API.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Mail obligatoire")]
        [EmailAddress]
        public required string Email { get; set; }
        [Required(ErrorMessage = "MDP obligatoire")]
        public required string Password { get; set; }
    }
}
