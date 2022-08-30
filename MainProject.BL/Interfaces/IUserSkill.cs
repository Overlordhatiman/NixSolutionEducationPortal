namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IUserSkill
    {
        public UserSkillDTO AddUserSkill(UserSkillDTO userSkill);

        public UserSkillDTO UpdateUserSkill(UserSkillDTO userSkill);

        public List<UserSkillDTO> GetAllUserSkill();

        public bool DeleteUserSkill(int id);

        public UserSkillDTO GetUserSkill(int id);
    }
}
