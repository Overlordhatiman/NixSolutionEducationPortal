namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions.Mapping;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserDTO AddUser(UserDTO user)
        {
            _unitOfWork.UserRepository.AddUser(user.ToModel());

            return user;
        }

        public bool DeleteUser(int id)
        {
            var result = _unitOfWork.UserRepository.DeleteUser(id);

            return result != null;
        }

        public List<UserDTO> GetAllUser()
        {
            List<UserDTO> users = new List<UserDTO>();
            foreach (var user in _unitOfWork.UserRepository.GetAllUser())
            {
                users.Add(user.ToDTO());
            }

            return users;
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            _unitOfWork.UserRepository.UpdateUser(user.ToModel());

            return user;
        }

        public bool IsValidUser(string mail, string password)
        {
            return _unitOfWork.UserRepository.IsValidUser(mail, password);
        }

        public UserDTO GetUser(int id)
        {
            return _unitOfWork.UserRepository.GetUser(id).ToDTO();
        }

        public UserDTO GetUser(string mail, string password)
        {
            return _unitOfWork.UserRepository.GetUser(mail, password).ToDTO();
        }
    }
}
