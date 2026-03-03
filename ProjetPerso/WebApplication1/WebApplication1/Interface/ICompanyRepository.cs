using WebApplication1.Entities;

namespace WebApplication1.Interface
{
    public interface ICompanyRepository
    {
        Task<Company?> GetByIdAsync(Guid id);
        Task<IEnumerable<Company>> GetAllAsync();
        Task AddAsync(Company company);
    }
}
