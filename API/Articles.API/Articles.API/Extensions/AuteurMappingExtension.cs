using Articles.API.Data;
using Articles.API.Dtos;
using Articles.API.Models;

namespace Articles.API.Extensions
{
    public static class AuteurMappingExtension
    {
        public static AuteurDto ToAuteurDto(this Auteur auteur)
        {

            return new AuteurDto
            {
                Id = auteur.Id,
                Nom = auteur.Nom,
                Prenom = auteur.Prenom,
            };
        }

        public static Auteur ToAuteur(this AuteurCreateDto dto)
        {
            return new Auteur
            {
                Nom = dto.Nom,
                Prenom = dto.Prenom,
            };
        }
    }
}
