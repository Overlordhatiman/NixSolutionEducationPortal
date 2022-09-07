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

        public async Task<User> AddUser(User user)
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
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var entityToDelete = _context.Users.SingleOrDefault(e => e.Id == id);
            var obj = _context.Users.Remove(entityToDelete);
            await _context.SaveChangesAsync();

            return obj != null;
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
            await _context.SaveChangesAsync();

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
