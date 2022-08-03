using MainProject.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.Interfaces
{
    public interface IUserRepository
    {
        public User AddUser(User user);
        public User UpdateUser(int id, User user);
        public List<User> GetAllUser();
        public bool DeleteUser(User user);
    }
}
