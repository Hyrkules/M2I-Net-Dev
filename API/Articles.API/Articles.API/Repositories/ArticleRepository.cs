using Articles.API.Data;
using Articles.API.Models;
using Microsoft.AspNetCore.Routing.Internal;

namespace Articles.API.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public void Add(Article article)
        {
            article.Id = DbFake.Articles.Any() ?
                DbFake.Articles.Max(a => a.Id) + 1 : 1;

            DbFake.Articles.Add(article);
        }

        public void Delete(int id)
        {
            var article = GetById(id);

            if (article != null)
            {
                DbFake.Articles.Remove(article);
            }
        }

        public List<Article> GetAll()
        {
            return DbFake.Articles.ToList();
        }

        public List<Article> GetByAuteurId(int auteurId)
        {
            return DbFake.Articles.Where(a => a.AuteurId == auteurId).ToList();
        }

        public Article? GetById(int id)
        {
            return DbFake.Articles.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Article article)
        {
            var index = DbFake.Articles.FindIndex(a => a.Id == article.Id);

            if (index == -1) {
                DbFake.Articles[index] = article;
            
            }
        }
    }
}
