using MainProject.BL.DTO;

namespace MainProject.BL.Interfaces
{
    public interface ISkillService
    {
        public SkillDTO AddSkill(SkillDTO skill);
        public SkillDTO UpdateSkill(int id, SkillDTO skill);
        public List<SkillDTO> GetAllSkill();
        public bool DeleteSkill(SkillDTO skill);
    }
}
