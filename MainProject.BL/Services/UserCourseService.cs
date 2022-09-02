namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions.Mapping;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using System.Collections.Generic;

    public class UserCourseService : IUserCourse
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserCourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserCourseDTO AddUserCourse(UserCourseDTO userCourse)
        {
            _unitOfWork.UserCoursesRepository.AddUserCourse(userCourse.ToModel());

            return userCourse;
        }

        public bool DeleteUserCourse(int id)
        {
            var result = _unitOfWork.UserCoursesRepository.DeleteUserCourse(id);

            return result != null;
        }

        public List<UserCourseDTO> GetAllUserCourse()
        {
            List<UserCourseDTO> userCourses = new List<UserCourseDTO>();

            foreach (var userCourse in _unitOfWork.UserCoursesRepository.GetAllUserCourse())
            {
                userCourses.Add(userCourse.ToDTO());
            }

            return userCourses;
        }

        public UserCourseDTO GetUserCourse(int id)
        {
            return _unitOfWork.UserCoursesRepository.GetUserCourse(id).ToDTO();
        }

        public List<UserCourseDTO> GetUserCourseForUser(int id)
        {
            List<UserCourseDTO> userCourses = new List<UserCourseDTO>();

            foreach (var userCourse in _unitOfWork.UserCoursesRepository.GetUserCourseForUser(id))
            {
                userCourses.Add(userCourse.ToDTO());
            }

            return userCourses;
        }

        public UserCourseDTO UpdateUserCourse(UserCourseDTO userCourse)
        {
            _unitOfWork.UserCoursesRepository.UpdateUserCourse(userCourse.ToModel());

            return userCourse;
        }
    }
}
