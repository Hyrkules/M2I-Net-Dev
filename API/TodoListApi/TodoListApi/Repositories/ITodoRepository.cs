using TodoListApi.Models;

namespace TodoListApi.Repositories
{
    public interface ITodoRepository
    {
        List<TodoItem> GetAll();
        List<TodoItem> GetByStatus(bool isCompleted);
        TodoItem? GetById(int id);
        void Add(TodoItem item);
        void Update(TodoItem item);
        void Delete(int id);
    }
}
