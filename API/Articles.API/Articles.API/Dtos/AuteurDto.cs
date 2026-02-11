using System.ComponentModel.DataAnnotations;

namespace Articles.API.Dtos
{
    public class AuteurDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
    }
}
