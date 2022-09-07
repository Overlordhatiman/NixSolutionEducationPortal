namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class DbUserCourseRepository : IUserCourseRepository
    {
        private EducationPortalContext _context;

        public DbUserCourseRepository(EducationPortalContext context)
        {
            _context = context;
        }

        public async Task<UserCourse> AddUserCourse(UserCourse userCourse)
        {
            if (userCourse == null)
            {
                throw new NullReferenceException();
            }

            userCourse.Course = _context.Courses.FirstOrDefault(course => course.Id == userCourse.Course.Id);
            userCourse.User = _context.Users.FirstOrDefault(user => user.Id == userCourse.User.Id);

            _context.UserCourses.Add(userCourse);
            await _context.SaveChangesAsync();

            return userCourse;
        }

        public async Task<bool> DeleteUserCourse(int id)
        {
            var entityToDelete = _context.UserCourses.SingleOrDefault(e => e.Id == id);
            var obj = _context.UserCourses.Remove(entityToDelete);
            await _context.SaveChangesAsync();

            return obj != null;
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
                .AsNoTracking()
                .Include(user => user.User)
                .Include(course => course.Course)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<UserCourse>> GetUserCourseForUser(int id)
        {
            return await _context.UserCourses
                .AsNoTracking()
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

            userCourse.Course = _context.Courses.FirstOrDefault(course => course.Id == userCourse.Course.Id);
            userCourse.User = _context.Users.FirstOrDefault(user => user.Id == userCourse.User.Id);

            _context.UserCourses.Update(userCourse);
            await _context.SaveChangesAsync();

            return userCourse;
        }
    }
}
