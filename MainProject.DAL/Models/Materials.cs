namespace MainProject.DAL.Models
{
    public class Materials
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? CourseId { get; set; }

        public Course? Course { get; set; }
    }
}
