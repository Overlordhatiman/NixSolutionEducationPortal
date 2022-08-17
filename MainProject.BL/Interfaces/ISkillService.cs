namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface ISkillService
    {
        public SkillDTO AddSkill(SkillDTO skill);

        public SkillDTO UpdateSkill(SkillDTO skill);

        public List<SkillDTO> GetAllSkill();

        public bool DeleteSkill(int id);

        public SkillDTO GetSkill(int id);
    }
}
