namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions.Mapping;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;
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
            _unitOfWork.UserCoursesRepository.Add(userCourse.ToModel());

            return userCourse;
        }

        public bool DeleteUserCourse(int id)
        {
            var result = _unitOfWork.UserCoursesRepository.Delete(id);

            return result != null;
        }

        public List<UserCourseDTO> GetAllUserCourse()
        {
            List<UserCourseDTO> userCourses = new List<UserCourseDTO>();

            foreach (var userCourse in _unitOfWork.UserCoursesRepository.GetAll())
            {
                userCourses.Add(userCourse.ToDTO());
            }

            return userCourses;
        }

        public UserCourseDTO GetUserCourse(int id)
        {
            return _unitOfWork.UserCoursesRepository.GetById(id).ToDTO();
        }

        public UserCourseDTO UpdateUserCourse(UserCourseDTO userCourse)
        {
            _unitOfWork.UserCoursesRepository.Update(userCourse.ToModel());

            return userCourse;
        }
    }
}
