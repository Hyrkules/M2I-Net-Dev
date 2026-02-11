using Articles.API.Dtos;

namespace Articles.API.Services
{
    public interface IAuthService
    {
        LoginResponseDto Authenticate(LoginDto loginDto);
    }
}
