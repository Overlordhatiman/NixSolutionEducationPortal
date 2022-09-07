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

        public async Task<Course> AddCourse(Course course)
        {
            if (course == null)
            {
                throw new NullReferenceException();
            }

            course.Materials = course.Materials
                .Select(material => _context.Materials
                .FirstOrDefault(m => m.Id == material.Id) ?? material)
                .ToList();

            course.Skills = course.Skills
                .Select(skill => _context.Skills
                .FirstOrDefault(m => m.Id == skill.Id) ?? skill)
                .ToList();

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            var entityToDelete = _context.Courses.SingleOrDefault(e => e.Id == id);
            var obj = _context.Courses.Remove(entityToDelete);
            await _context.SaveChangesAsync();

            return obj != null;
        }

        public async Task<IEnumerable<Course>> GetAllCourse()
        {
           return await _context.Courses
                .AsNoTracking()
                .Include(material => material.Materials)
                .Include(skill => skill.Skills)
                .ToListAsync();
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            if (course == null)
            {
                throw new NullReferenceException();
            }

            course.Materials = course.Materials
                .Select(material => _context.Materials
                .FirstOrDefault(m => m.Id == material.Id) ?? material)
                .ToList();

            course.Skills = course.Skills
                .Select(skill => _context.Skills
                .FirstOrDefault(m => m.Id == skill.Id) ?? skill)
                .ToList();

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course> GetCourse(int id)
        {
            return await _context.Courses
                .AsNoTracking()
                .Include(skill => skill.Skills)
                .Include(material => material.Materials)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
