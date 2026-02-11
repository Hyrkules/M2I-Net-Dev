using TodoListBlazor.Dtos;

namespace TodoListBlazor.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(int id);
        Task<TodoItem?> CreateAsync(CreateTodoDto createDto);
        Task<bool> UpdateAsync(TodoItem todo);
        Task<bool> DeleteAsync(int id);
        Task<bool> ToggleAsync(int id);

    }
}
