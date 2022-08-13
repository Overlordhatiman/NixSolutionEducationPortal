namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface ISkillService
    {
        public Task<SkillDTO> AddSkill(SkillDTO skill);

        public Task<SkillDTO> UpdateSkill(int id, SkillDTO skill);

        public List<SkillDTO> GetAllSkill();

        public Task<bool> DeleteSkill(int id);
    }
}
