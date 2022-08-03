using MainProject.BL.DTO;
using MainProject.BL.Extentions;
using MainProject.BL.Interfaces;
using MainProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public UserDTO AddUser(UserDTO user)
        {
            _unitOfWork.UserRepository.AddUser(user.ToModel());
            _unitOfWork.Save();

            return user;
        }

        public bool DeleteUser(UserDTO user)
        {
            bool result = _unitOfWork.UserRepository.DeleteUser(user.ToModel());
            _unitOfWork.Save();

            return result;
        }

        public List<UserDTO> GetAllUser()
        {
            List<UserDTO> users = new List<UserDTO>();
            foreach (var item in _unitOfWork.UserRepository.GetAllUser())
            {
                users.Add((item).ToDTO());
            }

            return users;
        }

        public UserDTO UpdateUser(int id, UserDTO user)
        {
            _unitOfWork.UserRepository.UpdateUser(id, (user).ToModel());
            _unitOfWork.Save();

            return user;
        }
    }
}
