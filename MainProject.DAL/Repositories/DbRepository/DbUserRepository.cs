namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbUserRepository : BaseRepository<User>, IUserRepository
    {
        private EducationPortalContext _context;

        public DbUserRepository(EducationPortalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            if (user == null)
            {
                throw new NullReferenceException();
            }

            await Add(user);

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await Delete(id);
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
           return await _context.Users
                .AsNoTracking()
                .Include(materials => materials.Materials)
                .Include(userSkill => userSkill.UserSkills)
                .Include(userCourse => userCourse.UserCourses)
                .ToListAsync();
        }

        public async Task<bool> IsValidUser(string mail, string password)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Mail == mail && x.Password == password);

            return user != null;
        }

        public async Task<User> UpdateUser(User user)
        {
            if (user == null)
            {
                throw new NullReferenceException();
            }

            await Update(user);

            return user;
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(materials => materials.Materials)
                .Include(userSkill => userSkill.UserSkills)
                .Include(userCourse => userCourse.UserCourses)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUser(string mail, string password)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(materials => materials.Materials)
                .Include(userSkill => userSkill.UserSkills)
                .Include(userCourse => userCourse.UserCourses)
                .FirstOrDefaultAsync(x => x.Mail == mail && x.Password == password);
        }
    }
}
