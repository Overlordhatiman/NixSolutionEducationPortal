namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class DbUserCourseRepository : BaseRepository<UserCourse>, IUserCourseRepository
    {
        private EducationPortalContext _context;

        public DbUserCourseRepository(EducationPortalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserCourse> AddUserCourse(UserCourse userCourse)
        {
            if (userCourse == null)
            {
                throw new NullReferenceException();
            }

            await Add(userCourse);

            return userCourse;
        }

        public async Task<bool> DeleteUserCourse(int id)
        {
            return await Delete(id);
        }

        public async Task<IEnumerable<UserCourse>> GetAllUserCourse()
        {
            return await _context.UserCourses
                .Include(user => user.User)
                .Include(course => course.Course)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UserCourse> GetUserCourse(int id)
        {
            return await _context.UserCourses
                .Include(user => user.User)
                .Include(course => course.Course)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<UserCourse>> GetUserCourseForUser(int id)
        {
            return await _context.UserCourses
                .Include(user => user.User)
                .Include(course => course.Course)
                .Where(x => x.User.Id == id)
                .ToListAsync();
        }

        public async Task<UserCourse> UpdateUserCourse(UserCourse userCourse)
        {
            if (userCourse == null)
            {
                throw new NullReferenceException();
            }

            await Update(userCourse);

            return userCourse;
        }
    }
}
