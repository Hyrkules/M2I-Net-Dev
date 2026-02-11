using TodoListBlazor.Dtos;

namespace TodoListBlazor.Services
{
    public interface IAuthService
    {
        Task<(bool Success, string? ErrorMessage )> LoginAsync(LoginDto loginDto);

        Task<(bool Success, string? ErrorMessage)> RegisterAsync(RegisterDto registerDto);

        Task LogoutAsync();

        Task<string?> GetTokenAsync();

        Task<bool> IsAuthenticatedAsync();
    }
}
