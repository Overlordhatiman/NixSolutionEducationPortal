namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IUserCourse
    {
        public UserCourseDTO AddUserCourse(UserCourseDTO userCourse);

        public UserCourseDTO UpdateUserCourse(UserCourseDTO userCourse);

        public List<UserCourseDTO> GetAllUserCourse();

        public bool DeleteUserCourse(int id);

        public UserCourseDTO GetUserCourse(int id);

        public List<UserCourseDTO> GetUserCourseForUser(int id);
    }
}
