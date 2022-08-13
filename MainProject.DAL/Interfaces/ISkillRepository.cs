namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface ISkillRepository
    {
        public Skill AddSkill(Skill skill);

        public Skill UpdateSkill(int id, Skill skill);

        public IEnumerable<Skill> GetAllSkill();

        public bool DeleteSkill(int id);
    }
}
