namespace Data.DTOs
{
    public class LocationRetriveDTO
    {
        public int LocationId { get; set; }

        public string Name { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;
    }
}
