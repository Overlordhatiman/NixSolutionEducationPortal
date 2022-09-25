namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IUserService
    {
        public Task<UserDTO> AddUser(UserDTO user);

        public Task<UserDTO> UpdateUser(UserDTO user);

        public Task<IEnumerable<UserDTO>> GetAllUser();

        public Task<bool> DeleteUser(int id);

        public Task<bool> IsValidUser(string mail, string password);

        public Task<UserDTO> GetUser(int id);

        public Task<UserDTO> GetUser(string mail, string password);

        public Task<UserDTO> GetUser(string mail);
    }
}
