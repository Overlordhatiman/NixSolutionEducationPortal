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
            var user = _context.Users.FirstOrDefault(x => x.Mail == mail && x.Password == password);

            return user != null;
        }

        public User UpdateUser(User user)
        {
            if (user == null)
            {
                throw new NullReferenceException();
            }

            _context.Update(user);
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
                .SingleOrDefault(x => x.Mail == mail && x.Password == password);
        }
    }
}
