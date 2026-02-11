using System.ComponentModel.DataAnnotations;

namespace TodoListBlazor.Dtos
{
    public class CreateTodoDto
    {
        [Required(ErrorMessage= "Title is required.")]
        [StringLength(200, MinimumLength = 10,ErrorMessage = "Title must contain between 10 to 200 characters.")]
        public string Title { get; set; } = string.Empty;
        [StringLength(500, ErrorMessage = "Description cannot have more than 500 characters")]
        public string Description { get; set; } = string.Empty;
        [Range(1, 5, ErrorMessage = "Priority must be between 1 (Basse) and 5 (Urgente).")]
        public int Priority { get; set; } = 2;
        public DateTime DueDate { get; set; }
    }
}
