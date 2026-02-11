using Articles.API.Dtos;

namespace Articles.API.Services
{
    public interface IAuteurService
    {
        List<AuteurDto> GetAll();
        AuteurDto? GetById(int id);
        AuteurDto Add(AuteurCreateDto dto);
    }
}
