namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface ISkillService
    {
        public SkillDTO AddSkill(SkillDTO skill);

        public SkillDTO UpdateSkill(int id, SkillDTO skill);

        public List<SkillDTO> GetAllSkill();

        public bool DeleteSkill(int id);
    }
}
