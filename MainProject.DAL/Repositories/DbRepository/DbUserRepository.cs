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
           return _context.Users.AsNoTracking().ToList();
        }

        public bool IsValidUser(string mail, string password)
        {
            var user = _context.Users.FirstOrDefaultAsync(x => x.Mail == mail && x.Password == password);

            return user != null;
        }

        public User UpdateUser(User user)
        {
            if (user == null)
            {
                return null;
            }

            _context.Update(user);
            _context.SaveChanges();

            return user;
        }

        public User GetUser(int id)
        {
            return _context.Users.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }
    }
}
