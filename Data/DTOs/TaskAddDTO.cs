using Data.Entities.ToDoListDatabase;

namespace Data.DTOs
{
    public class TaskAddDTO
    {
        public string Titile { get; set; } = null!;
        public int UserId { get; set; }
        public int? LayoutId { get; set; }
    }
}
