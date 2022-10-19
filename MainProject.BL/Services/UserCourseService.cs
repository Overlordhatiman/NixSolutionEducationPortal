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

            int percent = await GetPercent(userCourse.Course.Id, userCourse.User.Id);

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

        public async Task FinishMaterial(int id, UserDTO userDTO)
        {
            if (userDTO != null)
            {
                Materials material = await _unitOfWork.MaterialsRepository.GetMaterials(id);
                User user = await _unitOfWork.UserRepository.GetUser(userDTO.Id);
                user.Materials.Add(material);
                await _unitOfWork.UserRepository.UpdateUser(user);
                await UpdateUserCourses(user.Id);
            }
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

        public async Task CheckSkills(int courseId, int userId)
        {
            int percent = await GetPercent(courseId, userId);
            if (percent == 100)
            {
                await UpdateSkills(userId, courseId);
            }
        }

        private async Task UpdateSkills(int userId, int courseId)
        {
            var userSkills = (await _unitOfWork.UserSkillsRepository.GetAllUserSkill()).Where(user => user.User.Id == userId);
            var user = await _unitOfWork.UserRepository.GetUser(userId);
            var course = await _unitOfWork.CourseRepository.GetCourse(courseId);
            foreach (var skill in course.Skills)
            {
                var userSkill = user.UserSkills.FirstOrDefault(x => x.Skill.Id == skill.Id);
                if (userSkill != null)
                {
                    userSkill.LevelOfSkill++;
                }
                else
                {
                    var userAddedSkill = new UserSkill
                    {
                        User = user,
                        Skill = skill,
                        LevelOfSkill = 0
                    };

                    user.UserSkills.Add(userAddedSkill);
                }

                await _unitOfWork.UserRepository.UpdateUser(user);
            }
        }

        private async Task UpdateUserCourses(int userId)
        {
            var user = (await _unitOfWork.UserRepository.GetUser(userId));
            var allCourses = (await _unitOfWork.UserCoursesRepository.GetAllUserCourse()).Where(user => user.User.Id == userId && user.Percent != 100);
            foreach (var userCourse in allCourses)
            {
                int percent = await GetPercent(userCourse.Course.Id, user.Id);
                userCourse.Percent = percent;
                userCourse.IsFinished = percent == 100;

                if (percent == 100)
                {
                    await UpdateSkills(user.Id, userCourse.Course.Id);
                }
            }
        }

        private async Task<int> GetPercent(int courseId, int userId)
        {
            int result = 0;
            if (courseId == null || userId == null)
            {
                return result;
            }

            var courses = await _unitOfWork.CourseRepository.GetCourse(courseId);
            var users = await _unitOfWork.UserRepository.GetUser(userId);

            int def = 1;
            int percentForOneMaterial;
            if (courses.Materials.Count() == 0)
            {
                percentForOneMaterial = (int)Math.Ceiling((decimal)100 / def);
            }
            else
            {
                percentForOneMaterial = (int)Math.Ceiling((decimal)100 / courses.Materials.Count());
            }

            foreach (var course in courses.Materials)
            {
                foreach (var material in users.Materials)
                {
                    if (course.Id == material.Id)
                    {
                        result += percentForOneMaterial;
                    }
                }
            }

            return result > 100 ? 100 : result;
        }
    }
}
