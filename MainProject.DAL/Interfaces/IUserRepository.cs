namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IUserRepository
    {
        public Task<User> AddUser(User user);

        public Task<User> UpdateUser(User user);

        public Task<IEnumerable<User>> GetAllUser();

        public Task<bool> DeleteUser(int id);

        public Task<bool> IsValidUser(string mail, string password);

        public Task<User> GetUser(int id);

        public Task<User> GetUser(string mail, string password);

        public Task<User> GetUser(string mail);
    }
}
