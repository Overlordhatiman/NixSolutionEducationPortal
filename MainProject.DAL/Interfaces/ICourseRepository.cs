namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface ICourseRepository
    {
        public Course AddCourse(Course course);

        public Task<Course> UpdateCourse(Course course);

        public Task<IEnumerable<Course>> GetAllCourse();

        public Task<bool> DeleteCourse(int id);

        public Task<Course> GetCourse(int id);
    }
}
