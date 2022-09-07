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

        public async Task<UserCourseDTO> AddUserCourse(UserCourseDTO userCourse)
        {
            await _unitOfWork.UserCoursesRepository.AddUserCourse(userCourse.ToModel());

            return userCourse;
        }

        public async Task<bool> DeleteUserCourse(int id)
        {
            var result = await _unitOfWork.UserCoursesRepository.DeleteUserCourse(id);

            return result != null;
        }

        public async Task<List<UserCourseDTO>> GetAllUserCourse()
        {
            List<UserCourseDTO> userCourses = new List<UserCourseDTO>();

            foreach (var userCourse in await _unitOfWork.UserCoursesRepository.GetAllUserCourse())
            {
                userCourses.Add(userCourse.ToDTO());
            }

            return userCourses;
        }

        public async Task<UserCourseDTO> GetUserCourse(int id)
        {
            return UserCourseMapping.ToDTO(await _unitOfWork.UserCoursesRepository.GetUserCourse(id));
        }

        public async Task<List<UserCourseDTO>> GetUserCourseForUser(int id)
        {
            List<UserCourseDTO> userCourses = new List<UserCourseDTO>();

            foreach (var userCourse in await _unitOfWork.UserCoursesRepository.GetUserCourseForUser(id))
            {
                userCourses.Add(userCourse.ToDTO());
            }

            return userCourses;
        }

        public async Task<UserCourseDTO> UpdateUserCourse(UserCourseDTO userCourse)
        {
            await _unitOfWork.UserCoursesRepository.UpdateUserCourse(userCourse.ToModel());

            return userCourse;
        }
    }
}
