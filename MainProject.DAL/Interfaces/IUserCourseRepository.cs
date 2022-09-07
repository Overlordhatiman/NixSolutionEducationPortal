namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IUserCourseRepository
    {
        public Task<UserCourse> AddUserCourse(UserCourse userCourse);

        public Task<UserCourse> UpdateUserCourse(UserCourse userCourse);

        public Task<IEnumerable<UserCourse>> GetAllUserCourse();

        public Task<bool> DeleteUserCourse(int id);

        public Task<UserCourse> GetUserCourse(int id);

        public Task<IEnumerable<UserCourse>> GetUserCourseForUser(int id);
    }
}
