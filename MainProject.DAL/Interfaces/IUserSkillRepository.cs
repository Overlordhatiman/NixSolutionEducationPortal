namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IUserSkillRepository
    {
        public UserSkill AddUserSkill(UserSkill userSkill);

        public UserSkill UpdateUserSkill(UserSkill userSkill);

        public IEnumerable<UserSkill> GetAllUserSkill();

        public bool DeleteUserSkill(int id);

        public UserSkill GetUserSkill(int id);
    }
}
