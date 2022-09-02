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

        public UserSkill AddUserSkill(UserSkill userSkill)
        {
            _context.UserSkills.Add(userSkill);
            _context.SaveChanges();

            return userSkill;
        }

        public bool DeleteUserSkill(int id)
        {
            var entityToDelete = _context.UserSkills.SingleOrDefault(e => e.Id == id);
            var obj = _context.UserSkills.Remove(entityToDelete);
            _context.SaveChanges();

            return obj != null;
        }

        public IEnumerable<UserSkill> GetAllUserSkill()
        {
            return _context.UserSkills
                            .Include(user => user.User)
                            .Include(skill => skill.Skill)
                            .AsNoTracking()
                            .ToList();
        }

        public UserSkill GetUserSkill(int id)
        {
            return _context.UserSkills
                            .Include(user => user.User)
                            .Include(skill => skill.Skill)
                            .AsNoTracking()
                            .SingleOrDefault(x => x.Id == id);
        }

        public UserSkill UpdateUserSkill(UserSkill userSkill)
        {
            if (userSkill == null)
            {
                throw new NullReferenceException();
            }

            _context.Entry(userSkill).State = EntityState.Modified;
            _context.SaveChanges();

            return userSkill;
        }
    }
}
