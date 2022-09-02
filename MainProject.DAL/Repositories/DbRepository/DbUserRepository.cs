namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbUserRepository : IUserRepository
    {
        private EducationPortalContext _context;

        public DbUserRepository(EducationPortalContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            if (user == null)
            {
                throw new NullReferenceException();
            }

            user.Materials = user.Materials
                .Select(material => _context.Materials
                .FirstOrDefault(m => m.Id == material.Id) ?? material)
                .ToList();

            user.UserSkills = user.UserSkills
                .Select(userSkill => _context.UserSkills
                .FirstOrDefault(m => m.Id == userSkill.Id) ?? userSkill)
                .ToList();

            user.UserCourses = user.UserCourses
                .Select(userCourse => _context.UserCourses
                .FirstOrDefault(m => m.Id == userCourse.Id) ?? userCourse)
                .ToList();

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public bool DeleteUser(int id)
        {
            var entityToDelete = _context.Users.SingleOrDefault(e => e.Id == id);
            var obj = _context.Users.Remove(entityToDelete);
            _context.SaveChanges();

            return obj != null;
        }

        public IEnumerable<User> GetAllUser()
        {
           return _context.Users
                .AsNoTracking()
                .Include(materials => materials.Materials)
                .Include(userSkill => userSkill.UserSkills)
                .Include(userCourse => userCourse.UserCourses)
                .ToList();
        }

        public bool IsValidUser(string mail, string password)
        {
            var user = _context.Users.AsNoTracking().FirstOrDefault(x => x.Mail == mail && x.Password == password);

            return user != null;
        }

        public User UpdateUser(User user)
        {
            if (user == null)
            {
                throw new NullReferenceException();
            }

            user.Materials = user.Materials
                .Select(material => _context.Materials
                .FirstOrDefault(m => m.Id == material.Id) ?? material)
                .ToList();

            user.UserSkills = user.UserSkills
                .Select(userSkill => _context.UserSkills
                .FirstOrDefault(m => m.Id == userSkill.Id) ?? userSkill)
                .ToList();

            user.UserCourses = user.UserCourses
                .Select(userCourse => _context.UserCourses
                .FirstOrDefault(m => m.Id == userCourse.Id) ?? userCourse)
                .ToList();

            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }

        public User GetUser(int id)
        {
            return _context.Users
                .AsNoTracking()
                .Include(materials => materials.Materials)
                .Include(userSkill => userSkill.UserSkills)
                .Include(userCourse => userCourse.UserCourses)
                .SingleOrDefault(x => x.Id == id);
        }

        public User GetUser(string mail, string password)
        {
            return _context.Users
                .AsNoTracking()
                .Include(materials => materials.Materials)
                .Include(userSkill => userSkill.UserSkills)
                .Include(userCourse => userCourse.UserCourses)
                .FirstOrDefault(x => x.Mail == mail && x.Password == password);
        }
    }
}
