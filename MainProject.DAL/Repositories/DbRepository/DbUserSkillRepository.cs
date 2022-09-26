namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class DbUserSkillRepository : BaseRepository<UserSkill>, IUserSkillRepository
    {
        private EducationPortalContext _context;

        public DbUserSkillRepository(EducationPortalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserSkill> AddUserSkill(UserSkill userSkill)
        {
            await Add(userSkill);

            return userSkill;
        }

        public async Task<bool> DeleteUserSkill(int id)
        {
            return await Delete(id);
        }

        public async Task<IEnumerable<UserSkill>> GetAllUserSkill()
        {
            return await _context.UserSkills
                            .Include(user => user.User)
                            .Include(skill => skill.Skill)
                            .ToListAsync();
        }

        public async Task<UserSkill> GetUserSkill(int id)
        {
            return await _context.UserSkills
                            .Include(user => user.User)
                            .Include(skill => skill.Skill)
                            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserSkill> UpdateUserSkill(UserSkill userSkill)
        {
            if (userSkill == null)
            {
                throw new NullReferenceException();
            }

            await Update(userSkill);

            return userSkill;
        }
    }
}
