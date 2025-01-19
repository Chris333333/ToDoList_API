using Data.Entities.ToDoListDatabase;

namespace Data.DTOs
{
    public class TicketRetriveDTO
    {
        public int TaskId { get; set; }

        public string Titile { get; set; } = null!;

        public int UserId { get; set; }

        public DateTime CreateDt { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedDt { get; set; }

        public int? LayoutId { get; set; }

        public LayoutRetriveDTO Layout { get; set; }

        public UserRetriveDTO User { get; set; } = null!;
    }
}
