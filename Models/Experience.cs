namespace labb3_Blazor.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public required string Company { get; set; }
        public required string Role { get; set; }
        public required string Date { get; set; }
        public required string ImageUrl { get; set; }
    }
}
