namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IUserSkillRepository
    {
        public Task<UserSkill> AddUserSkill(UserSkill userSkill);

        public Task<UserSkill> UpdateUserSkill(UserSkill userSkill);

        public Task<IEnumerable<UserSkill>> GetAllUserSkill();

        public Task<bool> DeleteUserSkill(int id);

        public Task<UserSkill> GetUserSkill(int id);
    }
}
