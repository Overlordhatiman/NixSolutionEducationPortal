namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IUserService
    {
        public Task<UserDTO> AddUser(UserDTO user);

        public Task<UserDTO> UpdateUser(int id, UserDTO user);

        public List<UserDTO> GetAllUser();

        public Task<bool> DeleteUser(int id);

        public bool IsValidUser(string mail, string password);
    }
}
