using Data.Entities.ToDoListDatabase;

namespace Data.DTOs
{
    public class LayoutAddDTO
    {
        public int LayoutId { get; set; }

        public string Name { get; set; } = null!;

        public string Path { get; set; } = null!;

        public string? Description { get; set; }

        public int LocationId { get; set; }
    }
}
