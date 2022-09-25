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

        public async Task<IEnumerable<CourseDTO>> GetUserCourseForUser(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return new List<CourseDTO>();
            }

            List<CourseDTO> courses = new List<CourseDTO>();

            var userCourse = (await _unitOfWork.UserCoursesRepository
                                    .GetAllUserCourse())
                                    .Where(course => course.User.Id == userDTO.Id);

            var allCourses = await _unitOfWork.CourseRepository.GetAllCourse();

            foreach (var course in allCourses)
            {
                if (userCourse.FirstOrDefault(c => c.Course.Id == course.Id) == null)
                {
                    courses.Add(course.ToDTO());
                }
            }

            return courses;
        }

        public async Task<UserCourseDTO> AddUserCourse(UserCourseDTO userCourse)
        {
            if (userCourse == null)
            {
                return userCourse;
            }

            int percent = GetPercent(userCourse.Course, userCourse.User);

            User user = await _unitOfWork.UserRepository.GetUser(userCourse.User.Id);
            UserCourse course = new UserCourse
            {
                IsFinished = percent == 100,
                Percent = percent,
                User = user,
                Course = userCourse.Course.ToModel(_unitOfWork)
            };

            user.UserCourses.Add(course);

            if (user != null)
            {
                await _unitOfWork.UserRepository.UpdateUser(user);
            }

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

        private int GetPercent(CourseDTO courseDTO, UserDTO user)
        {
            int result = 0;
            if (courseDTO == null || user == null)
            {
                return result;
            }

            double percentForOneMaterial = (double)100 / (courseDTO.Materials.Count());

            foreach (var course in courseDTO.Materials)
            {
                foreach (var material in user.Materials)
                {
                    if (course.Id == material.Id)
                    {
                        result += (int)percentForOneMaterial;
                    }
                }
            }

            return result;
        }
    }
}
