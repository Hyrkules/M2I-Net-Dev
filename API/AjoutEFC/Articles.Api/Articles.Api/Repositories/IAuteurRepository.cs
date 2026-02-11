using Articles.Api.Models;

namespace Articles.Api.Repositories
{
    public interface IAuteurRepository
    {
        Task<List<Auteur>> GetAllAsync();
        Task<Auteur?> GetByIdAsync(int id);
        Task AddAsync(Auteur auteur);
        Task UpdateAsync(Auteur auteur);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
