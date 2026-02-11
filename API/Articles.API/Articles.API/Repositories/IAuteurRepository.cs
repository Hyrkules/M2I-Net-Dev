using Articles.API.Models;

namespace Articles.API.Repositories
{
    public interface IAuteurRepository
    {
        List<Auteur> GetAll();
        Auteur? GetById(int id);

        void Add(Auteur auteur);
        void Update(Auteur auteur);
        void Delete(int id);
    }
}
