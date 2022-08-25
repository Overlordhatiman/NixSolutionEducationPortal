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
            _context.SaveChanges();

            return skill;
        }

        public bool DeleteSkill(int id)
        {
            var entityToDelete = _context.Skills.SingleOrDefault(e => e.Id == id);
            var obj = _context.Skills.Remove(entityToDelete);
            _context.SaveChanges();

            return obj != null;
        }

        public IEnumerable<Skill> GetAllSkill()
        {
            return _context.Skills.Include(m => m.Courses).AsNoTracking().ToList();
        }

        public Skill UpdateSkill(Skill skill)
        {
            if (skill == null)
            {
                throw new NullReferenceException();
            }

            _context.Skills.Update(skill);
            _context.SaveChanges();

            return skill;
        }

        public Skill GetSkill(int id)
        {
            return _context.Skills.Include(m => m.Courses).SingleOrDefault(x => x.Id == id);
        }
    }
}
