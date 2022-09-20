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
            await _unitOfWork.UserCoursesRepository.AddUserCourse(userCourse.ToModel(_unitOfWork));

            return userCourse;
        }

        public async Task<bool> DeleteUserCourse(int id)
        {
            var result = await _unitOfWork.UserCoursesRepository.DeleteUserCourse(id);

            return result != null;
        }

        public async Task<IEnumerable<UserCourseDTO>> GetAllUserCourse()
        {
            return (await _unitOfWork.UserCoursesRepository.GetAllUserCourse()).Select(x => x.ToDTO());
        }

        public async Task<UserCourseDTO> GetUserCourse(int id)
        {
            return UserCourseMapping.ToDTO(await _unitOfWork.UserCoursesRepository.GetUserCourse(id));
        }

        public async Task<IEnumerable<UserCourseDTO>> GetUserCourseForUser(int id)
        {
            return (await _unitOfWork.UserCoursesRepository.GetUserCourseForUser(id)).Select(x => x.ToDTO());
        }

        public async Task<UserCourseDTO> UpdateUserCourse(UserCourseDTO userCourse)
        {
            await _unitOfWork.UserCoursesRepository.UpdateUserCourse(userCourse.ToModel(_unitOfWork));

            return userCourse;
        }
    }
}
