using Blazored.LocalStorage;
using System.Net.Http.Json;
using TodoListBlazor.Dtos;

namespace TodoListBlazor.Services
{
    public class AuthService : IAuthService
    {
        private const string TOKEN_KEY = "authtoken";

        private readonly HttpClient _http;

        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        public async Task<(bool Success, string? ErrorMessage)> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/auth/login", loginDto);

                if (response.IsSuccessStatusCode) { 
                    var authResponse= await response.Content.ReadFromJsonAsync<AuthResponse>();
                    if(authResponse?.Token != null)
                    {
                        await _localStorage.SetItemAsStringAsync(TOKEN_KEY, authResponse.Token);
                        return (true, null);
                    }
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, errorContent ?? "Identifiant incorrect !");
            }
            catch (HttpRequestException) 
            {
                return (false, "Impossible de contacter le serveur. Vérifiez que l'API est démarrée.");
            }
            catch (Exception ex)
            {
                return (false, $"Erreur : {ex.Message}");
            }
        }

        public async Task<string?> GetTokenAsync()
        {
            return await _localStorage.GetItemAsStringAsync(TOKEN_KEY);
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await GetTokenAsync();
            return !string.IsNullOrEmpty(token);
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync(TOKEN_KEY);
        }

        public async Task<(bool Success, string? ErrorMessage)> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/auth/login", registerDto);

                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }
                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, errorContent ?? "Erreur lors de l'inscription");

            }
            catch (HttpRequestException)
            {
                return (false, "Impossible de contacter le serveur. Vérifiez que l'API est démarrée.");
            }
            catch (Exception ex)
            {
                return (false, $"Erreur : {ex.Message}");
            }
        }
    }
}
