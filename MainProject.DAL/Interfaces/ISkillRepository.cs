namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface ISkillRepository
    {
        public Skill AddSkill(Skill skill);

        public Skill UpdateSkill(Skill skill);

        public IEnumerable<Skill> GetAllSkill();

        public bool DeleteSkill(int id);

        public Skill GetSkill(int id);
    }
}
