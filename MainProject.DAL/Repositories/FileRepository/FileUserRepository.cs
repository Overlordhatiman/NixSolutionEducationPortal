namespace MainProject.DAL.Repositories.FileRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Newtonsoft.Json;

    public class FileUserRepository : IUserRepository
    {
        private List<User>? _users;

        public FileUserRepository()
        {
            string str = File.ReadAllText(DALConstant.UserFilePath);

            _users = JsonConvert.DeserializeObject<List<User>>(str);
        }

        public User AddUser(User user)
        {
            _users.Add(user);

            return user;
        }

        public bool DeleteUser(int id)
        {
            return _users.Remove(_users.Find(x => x.Id == id));
        }

        public IEnumerable<User> GetAllUser()
        {
            return _users;
        }

        public User UpdateUser(int id, User user)
        {
            int index = _users.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return new User();
            }

            _users[index] = user;

            return user;
        }

        public bool IsValidUser(string mail, string password)
        {
            User user = _users.Find(x => x.Mail == mail && x.Password == password);
            return user != null;
        }

        public void Save()
        {
            var str = JsonConvert.SerializeObject(_users, Formatting.Indented);

            File.WriteAllText(DALConstant.UserFilePath, str);
        }
    }
}
