using Articles.API.Dtos;
using Articles.API.Extensions;
using Articles.API.Repositories;

namespace Articles.API.Services
{
    public class AuteurService : IAuteurService
    {
        private readonly IAuteurRepository _repository;

        public AuteurService(IAuteurRepository repository)
        {
            _repository = repository;
        }

        public AuteurDto Add(AuteurCreateDto dto)
        {
            var auteur = dto.ToAuteur();
            _repository.Add(auteur);
            return auteur.ToAuteurDto();
        }

        public List<AuteurDto> GetAll()
        {
            return _repository.GetAll().Select(a => a.ToAuteurDto()).ToList();
        }

        public AuteurDto? GetById(int id)
        { 

            var auteur = _repository.GetById(id);

            return auteur?.ToAuteurDto();
        }
    }
}
