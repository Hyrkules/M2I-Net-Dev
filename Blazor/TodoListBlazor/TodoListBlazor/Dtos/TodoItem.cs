namespace TodoListBlazor.Dtos
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public bool isCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }

        public string PriorityName => Priority switch
        {
            1 => "Basse",
            2 => "Moyenne",
            3 => "Haute",
            _ => "Inconnue"
        };

        public string PriorityBadgeClass => Priority switch
        {
            1 => "badge bg-success",
            2 => "badge bg-warning",
            3 => "badge bg-danger",
            _ => "badge bg-secondary"
        };

        public bool IsOverrdue => DueDate.HasValue && DueDate.Value < DateTime.Today && !isCompleted;

        public string FormattedDueDate => DueDate?.ToString("dd/MM/yyyy") ?? "Pas de date";
    }
}
