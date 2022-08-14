namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface ISkillRepository
    {
        public Skill AddSkill(Skill skill);

        public Task<Skill> UpdateSkill(Skill skill);

        public Task<IEnumerable<Skill>> GetAllSkill();

        public Task<bool> DeleteSkill(int id);

        public Task<Skill> GetSkill(int id);
    }
}
