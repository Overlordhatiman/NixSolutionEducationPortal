namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface ICourseRepository
    {
        public Course AddCourse(Course course);

        public Course UpdateCourse(int id, Course course);

        public IEnumerable<Course> GetAllCourse();

        public bool DeleteCourse(int id);
    }
}
