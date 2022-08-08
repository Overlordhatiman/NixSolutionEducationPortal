namespace MainProject.DAL.Interfaces
{
    using MainProject.src.Models;

    public interface ISkillRepository
    {
        public Skill AddSkill(Skill skill);

        public Skill UpdateSkill(int id, Skill skill);

        public List<Skill> GetAllSkill();

        public bool DeleteSkill(int id);
    }
}
