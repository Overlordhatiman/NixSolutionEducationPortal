namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> AddUser(UserDTO user)
        {
            _unitOfWork.UserRepository.AddUser(user.ToModel());
            await _unitOfWork.Save();

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            bool result = _unitOfWork.UserRepository.DeleteUser(id);
            await _unitOfWork.Save();

            return result;
        }

        public List<UserDTO> GetAllUser()
        {
            List<UserDTO> users = new List<UserDTO>();
            foreach (var item in _unitOfWork.UserRepository.GetAllUser())
            {
                users.Add(item.ToDTO());
            }

            return users;
        }

        public async Task<UserDTO> UpdateUser(int id, UserDTO user)
        {
            _unitOfWork.UserRepository.UpdateUser(id, user.ToModel());
            await _unitOfWork.Save();

            return user;
        }

        public bool IsValidUser(string mail, string password)
        {
            return _unitOfWork.UserRepository.IsValidUser(mail, password);
        }
    }
}
