namespace Data.DTOs
{
    public class UserRetriveDTO
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Login { get; set; } = null!;

        public LocationRetriveDTO Location { get; set; } = null!;

        public  WorkPositionRetriveDTO WorkPosition { get; set; } = null!;
    }
}
