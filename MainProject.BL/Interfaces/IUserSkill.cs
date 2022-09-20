namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IUserSkill
    {
        public Task<UserSkillDTO> AddUserSkill(UserSkillDTO userSkill);

        public Task<UserSkillDTO> UpdateUserSkill(UserSkillDTO userSkill);

        public Task<IEnumerable<UserSkillDTO>> GetAllUserSkill();

        public Task<bool> DeleteUserSkill(int id);

        public Task<UserSkillDTO> GetUserSkill(int id);
    }
}
