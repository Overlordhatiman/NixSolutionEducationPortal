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

        public Skill AddSkill(Skill skill)
        {
            _context.Skills.Add(skill);

            return skill;
        }

        public async Task<bool> DeleteSkill(int id)
        {
            var entityToDelete = await _context.Skills.SingleOrDefaultAsync(e => e.Id == id);
            var obj = _context.Skills.Remove(entityToDelete);

            return obj != null;
        }

        public async Task<IEnumerable<Skill>> GetAllSkill()
        {
            var skills = await _context.Skills.ToListAsync();

            return skills;
        }

        public async Task<Skill> UpdateSkill(Skill skill)
        {
            if (skill == null)
            {
                return null;
            }

            var skillObj = await _context.Skills.FirstOrDefaultAsync(x => x.Id == skill.Id);
            if (skillObj != null)
            {
                skillObj.Name = skill.Name;
            }

            _context.Entry(skillObj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return skillObj;
        }

        public Task<Skill> GetSkill(int id)
        {
            return _context.Skills.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
