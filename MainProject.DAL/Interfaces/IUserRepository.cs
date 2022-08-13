namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IUserRepository
    {
        public User AddUser(User user);

        public User UpdateUser(int id, User user);

        public IEnumerable<User> GetAllUser();

        public bool DeleteUser(int id);

        public bool IsValidUser(string mail, string password);
    }
}
