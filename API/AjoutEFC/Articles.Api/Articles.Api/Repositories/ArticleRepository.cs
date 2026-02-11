using Articles.Api.Data;
using Articles.Api.Models;
using Articles.Api_AvecBDD.Data;
using Microsoft.EntityFrameworkCore;

namespace Articles.Api.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Article article)
        {
            _context.Add(article);

            await _context.SaveChangesAsync();

            await _context.Entry(article).Reference(a=>a.Auteur).LoadAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if(article != null)
            {
                _context.Articles.Remove(article);

                await _context.SaveChangesAsync();
            }
        }

        //Recupère la liste d'articles de notre BDD
        public async Task<List<Article>> GetAllAsync()
        {
            return await _context.Articles
                .Include(a => a.Auteur)
                .ToListAsync();
        }

        public async Task<List<Article>> GetByAuteurIdAsync(int auteurId)
        {
            return await _context.Articles.Include(a => a.Auteur).Where(a=>a.AuteurId == auteurId).ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(int id)
        {
            return await _context.Articles.Include(a => a.Auteur).FirstOrDefaultAsync(a =>a.Id == id);
        }

        public async Task UpdateAsync(Article article)
        {
            _context.Articles.Update(article);

            await _context.SaveChangesAsync();

        }
    }
}
