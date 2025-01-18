using Data.Entities.ToDoListDatabase;

namespace Data.DTOs
{
    public class UserAddDTO
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Login { get; set; } = null!;

        public int LocationId { get; set; }

        public int WorkPositionId { get; set; }
    }
}
