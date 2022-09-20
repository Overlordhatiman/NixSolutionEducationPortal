namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbSkillRepository : ISkillRepository
    {
        private EducationPortalContext _context;

        public DbSkillRepository(EducationPortalContext context)
        {
            _context = context;
        }

        public async Task<Skill> AddSkill(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return skill;
        }

        public async Task<bool> DeleteSkill(int id)
        {
            var entityToDelete = _context.Skills.SingleOrDefault(e => e.Id == id);
            var obj = _context.Skills.Remove(entityToDelete);
            await _context.SaveChangesAsync();

            return obj != null;
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

            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();

            return skill;
        }

        public async Task<Skill> GetSkill(int id)
        {
            return await _context.Skills.Include(m => m.Courses).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
