namespace labb3_Blazor.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }
        public required string Status { get; set; }
        public DateTime? DateAchieved { get; set; }
        public required string CredentialUrl { get; set; }
    }
}
