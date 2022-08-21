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
            if (course == null)
            {
                return null;
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
            _context.SaveChanges();

            return course;
        }

        public bool DeleteCourse(int id)
        {
            var entityToDelete = _context.Courses.SingleOrDefault(e => e.Id == id);
            var obj = _context.Courses.Remove(entityToDelete);
            _context.SaveChanges();

            return obj != null;
        }

        public IEnumerable<Course> GetAllCourse()
        {
           return _context.Courses
                .Include(material => material.Materials)
                .Include(skill => skill.Skills)
                .AsNoTracking()
                .ToList();
        }

        public Course UpdateCourse(Course course)
        {
            if (course == null)
            {
                return null;
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
            _context.SaveChanges();

            return course;
        }

        public Course GetCourse(int id)
        {
            return _context.Courses.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }
    }
}
