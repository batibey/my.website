namespace my.website.Entities
{
    public class Projects
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? GithubLink { get; set; }
        public string? ProjectDescription { get; set; }
        public DateTime ProjectDate { get; set; }
        public string? Author { get; set; }
    }
}
