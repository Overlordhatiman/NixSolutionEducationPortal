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
            var result = await _unitOfWork.UserRepository.DeleteUser(id);
            await _unitOfWork.Save();

            return result != null;
        }

        public async Task<List<UserDTO>> GetAllUser()
        {
            List<UserDTO> users = new List<UserDTO>();
            foreach (var user in await _unitOfWork.UserRepository.GetAllUser())
            {
                users.Add(user.ToDTO());
            }

            return users;
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            await _unitOfWork.UserRepository.UpdateUser(user.ToModel());
            await _unitOfWork.Save();

            return user;
        }

        public async Task<bool> IsValidUser(string mail, string password)
        {
            return await _unitOfWork.UserRepository.IsValidUser(mail, password);
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var skill = await _unitOfWork.UserRepository.GetUser(id);

            return skill.ToDTO();
        }
    }
}
