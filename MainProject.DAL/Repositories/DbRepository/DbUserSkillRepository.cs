namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class DbUserSkillRepository : IUserSkillRepository
    {
        private EducationPortalContext _context;

        public DbUserSkillRepository(EducationPortalContext context)
        {
            _context = context;
        }

        public async Task<UserSkill> AddUserSkill(UserSkill userSkill)
        {
            _context.UserSkills.Add(userSkill);
            await _context.SaveChangesAsync();

            return userSkill;
        }

        public async Task<bool> DeleteUserSkill(int id)
        {
            var entityToDelete = _context.UserSkills.SingleOrDefault(e => e.Id == id);
            var obj = _context.UserSkills.Remove(entityToDelete);
            await _context.SaveChangesAsync();

            return obj != null;
        }

        public async Task<IEnumerable<UserSkill>> GetAllUserSkill()
        {
            return await _context.UserSkills
                            .Include(user => user.User)
                            .Include(skill => skill.Skill)
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<UserSkill> GetUserSkill(int id)
        {
            return await _context.UserSkills
                            .Include(user => user.User)
                            .Include(skill => skill.Skill)
                            .AsNoTracking()
                            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserSkill> UpdateUserSkill(UserSkill userSkill)
        {
            if (userSkill == null)
            {
                throw new NullReferenceException();
            }

            _context.Entry(userSkill).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return userSkill;
        }
    }
}
