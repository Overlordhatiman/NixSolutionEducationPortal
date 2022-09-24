namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbSkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        private EducationPortalContext _context;

        public DbSkillRepository(EducationPortalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Skill> AddSkill(Skill skill)
        {
            await Add(skill);

            return skill;
        }

        public async Task<bool> DeleteSkill(int id)
        {
            return await Delete(id);
        }

        public async Task<IEnumerable<Skill>> GetAllSkill()
        {
            return await _context.Skills.Include(m => m.Courses).ToListAsync();
        }

        public async Task<Skill> UpdateSkill(Skill skill)
        {
            if (skill == null)
            {
                throw new NullReferenceException();
            }

            await Update(skill);

            return skill;
        }

        public async Task<Skill> GetSkill(int id)
        {
            return await _context.Skills.Include(m => m.Courses).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
