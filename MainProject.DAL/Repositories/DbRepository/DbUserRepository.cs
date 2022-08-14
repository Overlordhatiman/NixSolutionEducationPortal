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

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var entityToDelete = await _context.Users.SingleOrDefaultAsync(e => e.Id == id);
            var obj = _context.Users.Remove(entityToDelete);

            return obj != null;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<bool> IsValidUser(string mail, string password)
        {
            var user = _context.Users.FirstOrDefaultAsync(x => x.Mail == mail && x.Password == password);

            return user != null;
        }

        public async Task<User> UpdateUser(User user)
        {
            if (user == null)
            {
                return null;
            }

            var userObj = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (userObj != null)
            {
                userObj.Mail = user.Mail;
                userObj.Password = user.Password;
            }

            _context.Entry(userObj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return userObj;
        }

        public Task<User> GetUser(int id)
        {
            return _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
