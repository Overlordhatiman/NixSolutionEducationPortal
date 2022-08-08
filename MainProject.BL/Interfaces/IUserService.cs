﻿namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IUserService
    {
        public UserDTO AddUser(UserDTO user);

        public UserDTO UpdateUser(int id, UserDTO user);

        public List<UserDTO> GetAllUser();

        public bool DeleteUser(int id);

        public bool IsValidUser(string mail, string password);
    }
}
