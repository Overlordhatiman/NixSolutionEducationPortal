namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

    public class DbCourseRepository : ICourseRepository
    {
        private EducationPortalContext _context;

        public DbCourseRepository(EducationPortalContext context)
        {
            _context = context;
        }

        public Course AddCourse(Course course)
        {
            _context.Courses.Add(course);

            return course;
        }

        public bool DeleteCourse(int id)
        {
            var obj = _context.Courses.Remove(_context.Courses.SingleOrDefault(e => e.Id == id));

            return obj != null;
        }

        public IEnumerable<Course> GetAllCourse()
        {
            return _context.Courses;
        }

        public Course UpdateCourse(int id, Course course)
        {
            var courseObj = _context.Courses.SingleOrDefault(x => x.Id == id);

            courseObj = course;

            return course;
        }
    }
}
