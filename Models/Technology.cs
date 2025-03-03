namespace labb3_Blazor.Models
{
    public class Technology
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int YearsOfExperience { get; set; }
        public required string SkillLevel { get; set; }
        public required string ImageUrl { get; set; }
    }
}
