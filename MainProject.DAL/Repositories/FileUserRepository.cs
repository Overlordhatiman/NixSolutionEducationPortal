using MainProject.DAL.Interfaces;
using MainProject.src.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.Repositories
{
    public class FileUserRepository : IUserRepository
    {
        private List<User> _users;

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

        public bool DeleteUser(User user)
        {
            return _users.Remove(user);
        }

        public List<User> GetAllUser()
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
        public void Save()
        {
            var str = JsonConvert.SerializeObject(_users, Formatting.Indented);

            File.WriteAllText(DALConstant.UserFilePath, str);
        }
    }
}
