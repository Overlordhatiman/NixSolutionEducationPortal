namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public UserDTO AddUser(UserDTO user)
        {
            this.unitOfWork.UserRepository.AddUser(user.ToModel());
            this.unitOfWork.Save();

            return user;
        }

        public bool DeleteUser(int id)
        {
            bool result = this.unitOfWork.UserRepository.DeleteUser(id);
            this.unitOfWork.Save();

            return result;
        }

        public List<UserDTO> GetAllUser()
        {
            List<UserDTO> users = new List<UserDTO>();
            foreach (var item in this.unitOfWork.UserRepository.GetAllUser())
            {
                users.Add(item.ToDTO());
            }

            return users;
        }

        public UserDTO UpdateUser(int id, UserDTO user)
        {
            this.unitOfWork.UserRepository.UpdateUser(id, user.ToModel());
            this.unitOfWork.Save();

            return user;
        }

        public bool IsValidUser(string mail, string password)
        {
            return this.unitOfWork.UserRepository.IsValidUser(mail, password);
        }
    }
}
