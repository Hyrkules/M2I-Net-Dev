using Articles.API.Dtos;
using Articles.API.Exceptions;
using Articles.API.Extensions;
using Articles.API.Repositories;

namespace Articles.API.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repository;

        public ArticleService(IArticleRepository repository)
        {
            _repository = repository;
        }

        public ArticleDto Add(ArticleCreateDto dto)
        {
            var article = dto.ToArticle();
            _repository.Add(article);
            return article.ToArticleDto();
        }

        public bool Delete(int id)
        {
            var article = _repository.GetById(id);

            if (article != null)
            {
                throw new NotFoundException($"Impossible de supprimer, l'article id : {id} n'existe pas");
            }

            _repository.Delete(id);

            return true;
        }

        public List<ArticleDto> GetAll()
        {
            return _repository.GetAll().Select(a=>a.ToArticleDto()).ToList();
        }

        public List<ArticleDto> GetByAuteurId(int auteurId)
        {
            return _repository.GetByAuteurId(auteurId).Select(a => a.ToArticleDto()).ToList();
        }

        public ArticleDto? GetById(int id)
        {
            var article = _repository.GetById(id);

            if(article == null)
            {
                throw new NotFoundException($"L'artile avec l'id {id} n'existe pas");
            }

            return article.ToArticleDto();
        }

        public bool Update(int id, ArticleUpdateDto dto)
        {
            var article = _repository.GetById(id);

            if(article == null)
            {
                throw new NotFoundException($"Impossible de modifier ! l'article {id} n'existe pas");
            }

            article.Titre = dto.Titre;
            article.Contenu = dto.Contenu;

            _repository.Update(article);

            return true;
        }
    }
}
