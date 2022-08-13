namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

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

        public bool DeleteSkill(int id)
        {
            var obj = _context.Skills.Remove(_context.Skills.SingleOrDefault(e => e.Id == id));

            return obj != null;
        }

        public IEnumerable<Skill> GetAllSkill()
        {
            return _context.Skills;
        }

        public Skill UpdateSkill(int id, Skill skill)
        {
            var skillObj = _context.Skills.SingleOrDefault(x => x.Id == id);

            skillObj = skill;

            return skill;
        }
    }
}
