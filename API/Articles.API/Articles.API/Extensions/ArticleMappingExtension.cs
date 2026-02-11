using Articles.API.Data;
using Articles.API.Dtos;
using Articles.API.Models;

namespace Articles.API.Extensions
{
    public static class ArticleMappingExtension
    {
        public static ArticleDto ToArticleDto(this Article article)
        {
            var auteur = article.Auteur ?? DbFake.Auteurs.FirstOrDefault(a => a.Id == article.AuteurId);

            return new ArticleDto
            {
                Id = article.Id,
                Titre = article.Titre,
                Contenu = article.Contenu,
                NomAuteur = auteur != null ? $"{auteur.Prenom} {auteur.Nom}" : "Auteur inconnu",
            };
        }

        public static Article ToArticle(this ArticleCreateDto Dto)
        {
            return new Article
            {
                Titre = Dto.Titre,
                Contenu = Dto.Contenu,
                AuteurId = Dto.AuteurId,
                Auteur = DbFake.Auteurs.FirstOrDefault(a => a.Id == Dto.AuteurId),
            };
        }

        
}
}
