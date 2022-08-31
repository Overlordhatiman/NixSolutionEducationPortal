namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IUserCourseRepository
    {
        public UserCourse AddUserCourse(UserCourse userCourse);

        public UserCourse UpdateUserCourse(UserCourse userCourse);

        public IEnumerable<UserCourse> GetAllUserCourse();

        public bool DeleteUserCourse(int id);

        public UserCourse GetUserCourse(int id);
    }
}
