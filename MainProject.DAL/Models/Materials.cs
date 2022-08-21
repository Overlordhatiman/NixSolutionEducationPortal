namespace MainProject.DAL.Models
{
    public class Materials
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<Course>? Courses { get; set; } = new List<Course>();
    }
}
