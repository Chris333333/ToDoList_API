namespace Data.DTOs
{
    public class CommentsForTicketRetriveDTO
    {
        public int CommentId { get; set; }

        public string Content { get; set; } = null!;

        public int UserId { get; set; }

        public DateTime CreateDt { get; set; }

        public string UserName { get; set; } = null!;

        public string UserSurname { get; set; } = null!;
    }
}
