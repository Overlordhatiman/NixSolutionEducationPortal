namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface ISkillService
    {
        public Task<SkillDTO> AddSkill(SkillDTO skill);

        public Task<SkillDTO> UpdateSkill(SkillDTO skill);

        public Task<IEnumerable<SkillDTO>> GetAllSkill();

        public Task<bool> DeleteSkill(int id);

        public Task<SkillDTO> GetSkill(int id);
    }
}
