using MainProject.BL.DTO;

namespace MainProject.BL.Interfaces
{
    public interface IUserService
    {
        public UserDTO AddUser(UserDTO user);
        public UserDTO UpdateUser(int id, UserDTO user);
        public List<UserDTO> GetAllUser();
        public bool DeleteUser(UserDTO user);
    }
}
