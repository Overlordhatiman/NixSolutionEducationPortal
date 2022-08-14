namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> DeleteCourse(int id)
        {
            var entityToDelete = await _context.Courses.SingleOrDefaultAsync(e => e.Id == id);
            var obj = _context.Courses.Remove(entityToDelete);

            return obj != null;
        }

        public async Task<IEnumerable<Course>> GetAllCourse()
        {
            var courses = await _context.Courses.ToListAsync();

            return courses;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            if (course == null)
            {
                return null;
            }

            var courseObj = await _context.Courses.FirstOrDefaultAsync(x => x.Id == course.Id);
            if (courseObj != null)
            {
                courseObj.Name = course.Name;
                courseObj.Description = course.Description;
                courseObj.Materials = course.Materials;
                courseObj.Skills = course.Skills;
            }

            _context.Entry(courseObj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return courseObj;
        }

        public Task<Course> GetCourse(int id)
        {
            return _context.Courses.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
