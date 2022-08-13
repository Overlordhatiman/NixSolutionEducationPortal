namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

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

            return user;
        }

        public bool DeleteUser(int id)
        {
            var obj = _context.Users.Remove(_context.Users.SingleOrDefault(e => e.Id == id));

            return obj != null;
        }

        public IEnumerable<User> GetAllUser()
        {
            return _context.Users;
        }

        public bool IsValidUser(string mail, string password)
        {
            User user = _context.Users.FirstOrDefault(x => x.Mail == mail && x.Password == password);

            return user != null;
        }

        public User UpdateUser(int id, User user)
        {
            var userObj = _context.Users.SingleOrDefault(x => x.Id == id);

            userObj = user;

            return user;
        }
    }
}
