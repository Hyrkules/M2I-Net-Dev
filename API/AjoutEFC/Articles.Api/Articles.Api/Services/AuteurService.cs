using Articles.Api.Dtos;
using Articles.Api.Exceptions;
using Articles.Api.Extensions;
using Articles.Api.Repositories;
using Articles.Api_AvecBDD.Data;

namespace Articles.Api.Services
{
    public class AuteurService : IAuteurService
    {
        private readonly IAuteurRepository _repository;
        public AuteurService(IAuteurRepository repository, IArticleRepository articleRepository)
        {
            _repository = repository;
        }

        public async Task<AuteurDto> AddAsync(AuteurCreateDto dto)
        {
            var auteur = dto.ToAuteur();
            await _repository.AddAsync(auteur);

            return auteur.ToAuteurDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AuteurDto>> GetAllAsync()
        {
            var auteur = await _repository.GetAllAsync();
            return auteur.Select(a => a.ToAuteurDto()).ToList();
        }

        public async Task<AuteurDto?> GetByIdAsync(int id)
        {
            var auteur = await _repository.GetByIdAsync(id);
            return auteur?.ToAuteurDto();
        }

        public async Task<AuteurDto?> UpdateAsync(int id, AuteurCreateDto dto)
        {
            var auteur = await _repository.GetByIdAsync(id);

            if (auteur == null) return null;

            auteur.Nom = dto.Nom;
            auteur.Prenom = dto.Prenom;

            await _repository.UpdateAsync(auteur);

            return auteur.ToAuteurDto();
        }
    }
}
