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

        public UserCourse AddUserCourse(UserCourse userCourse)
        {
            if (userCourse == null)
            {
                throw new NullReferenceException();
            }

            userCourse.Course = _context.Courses.FirstOrDefault(course => course.Id == userCourse.Course.Id);
            userCourse.User = _context.Users.FirstOrDefault(user => user.Id == userCourse.User.Id);

            _context.UserCourses.Add(userCourse);
            _context.SaveChanges();

            return userCourse;
        }

        public bool DeleteUserCourse(int id)
        {
            var entityToDelete = _context.UserCourses.SingleOrDefault(e => e.Id == id);
            var obj = _context.UserCourses.Remove(entityToDelete);
            _context.SaveChanges();

            return obj != null;
        }

        public IEnumerable<UserCourse> GetAllUserCourse()
        {
            return _context.UserCourses
                .Include(user => user.User)
                .Include(course => course.Course)
                .AsNoTracking()
                .ToList();
        }

        public UserCourse GetUserCourse(int id)
        {
            return _context.UserCourses
                .Include(user => user.User)
                .Include(course => course.Course)
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == id);
        }

        public UserCourse UpdateUserCourse(UserCourse userCourse)
        {
            if (userCourse == null)
            {
                throw new NullReferenceException();
            }

            userCourse.Course = _context.Courses.FirstOrDefault(course => course.Id == userCourse.Course.Id);
            userCourse.User = _context.Users.FirstOrDefault(user => user.Id == userCourse.User.Id);

            _context.UserCourses.Update(userCourse);
            _context.SaveChanges();

            return userCourse;
        }
    }
}
