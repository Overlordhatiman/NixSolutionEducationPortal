namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IUserCourse
    {
        public Task<UserCourseDTO> AddUserCourse(UserCourseDTO userCourse);

        public Task<UserCourseDTO> UpdateUserCourse(UserCourseDTO userCourse);

        public Task<List<UserCourseDTO>> GetAllUserCourse();

        public Task<bool> DeleteUserCourse(int id);

        public Task<UserCourseDTO> GetUserCourse(int id);

        public Task<List<UserCourseDTO>> GetUserCourseForUser(int id);
    }
}
