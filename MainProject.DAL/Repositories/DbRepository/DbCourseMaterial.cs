namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Models;

    public class DbCourseMaterial
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int MaterialId { get; set; }

        public Course Course { get; set; }

        public Materials Materials { get; set; }
    }
}
