using System.Net.Http.Headers;
using System.Net.Http.Json;
using TodoListBlazor.Dtos;

namespace TodoListBlazor.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _http;

        private readonly IAuthService _authService;

        public TodoService(HttpClient http, IAuthService authService)
        {
            _http = http;
            _authService = authService;
        }

        public async Task<TodoItem?> CreateAsync(CreateTodoDto todo)
        {
            try
            {
                await SetAuthorizationHeaderAsync();

                var response = await _http.PostAsJsonAsync("api/todo", todo);

                if (response.IsSuccessStatusCode) { 
                    return await response.Content.ReadFromJsonAsync<TodoItem>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await SetAuthorizationHeaderAsync();
                var response = await _http.DeleteAsync($"api/todo/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex) { 
                return false;
            }
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {

            try
            {
                await SetAuthorizationHeaderAsync();

                var url = "api/todo";

                var taches = await _http.GetFromJsonAsync<List<TodoItem>>(url);

                return taches ?? new List<TodoItem>();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("Error 401 : Token invalide ou expiré.");
                return new List<TodoItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur {ex}");
                return new List<TodoItem>();
            }

            
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            try
            {
                await SetAuthorizationHeaderAsync();

                return await _http.GetFromJsonAsync<TodoItem>($"api/todo/{id}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                return null;
            }
        }

        public async Task<bool> ToggleAsync(int id)
        {
            try
            {
                await SetAuthorizationHeaderAsync();
                var response = await _http.PatchAsync($"api/todo/{id}/complete", null);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TodoItem todo)
        {
            try
            {
                await SetAuthorizationHeaderAsync();
                var response = await _http.PutAsJsonAsync($"api/todo/{todo.Id}", todo);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        private async Task SetAuthorizationHeaderAsync()
        {
            var token = await _authService.GetTokenAsync();

            if (!string.IsNullOrEmpty(token))
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
