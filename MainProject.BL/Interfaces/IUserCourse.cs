namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IUserCourse
    {
        public Task<UserCourseDTO> AddUserCourse(UserCourseDTO userCourse);

        public Task<UserCourseDTO> UpdateUserCourse(UserCourseDTO userCourse);

        public Task<IEnumerable<UserCourseDTO>> GetAllUserCourse();

        public Task FinishMaterial(int id, UserDTO userDTO);

        public Task<bool> DeleteUserCourse(int id);

        public Task<UserCourseDTO> GetUserCourse(int id);

        public Task<IEnumerable<UserCourseDTO>> GetUserCourseForUser(int id);

        public Task<IEnumerable<CourseDTO>> GetUserCourseForUser(UserDTO userDTO);

        public Task CheckSkills(int courseId, int userId);
    }
}
