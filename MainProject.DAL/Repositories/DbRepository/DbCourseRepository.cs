namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbCourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private EducationPortalContext _context;

        public DbCourseRepository(EducationPortalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Course> AddCourse(Course course)
        {
            if (course == null)
            {
                throw new NullReferenceException();
            }

            await Add(course);

            return course;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            return await Delete(id);
        }

        public async Task<IEnumerable<Course>> GetAllCourse()
        {
           return await _context.Courses
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

            await Update(course);

            return course;
        }

        public async Task<Course> GetCourse(int id)
        {
            return await _context.Courses
                .Include(skill => skill.Skills)
                .Include(material => material.Materials)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
