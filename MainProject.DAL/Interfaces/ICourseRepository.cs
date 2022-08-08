namespace MainProject.DAL.Interfaces
{
    using MainProject.src.Models;

    public interface ICourseRepository
    {
        public Course AddCourse(Course course);

        public Course UpdateCourse(int id, Course course);

        public List<Course> GetAllCourse();

        public bool DeleteCourse(int id);
    }
}
