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

        public async Task FinishMaterial(int id, UserDTO userDTO)
        {
            if (userDTO != null)
            {
                Materials material = await _unitOfWork.MaterialsRepository.GetMaterials(id);
                User user = await _unitOfWork.UserRepository.GetUser(userDTO.Id);
                user.Materials.Add(material);
                await _unitOfWork.UserRepository.UpdateUser(user);
                await UpdateUserCourses(user);
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

        private async Task UpdateSkills(User user, Course course)
        {
            var userSkills = (await _unitOfWork.UserSkillsRepository.GetAllUserSkill()).Where(user => user.User.Id == user.Id);
            foreach (var skill in course.Skills)
            {
                UserSkill userSkill;
                if (userSkills.FirstOrDefault(userSkill => userSkill.Skill.Id == skill.Id) == null)
                {
                    userSkill = new UserSkill
                    {
                        LevelOfSkill = 0,
                        Skill = skill
                    };
                }
                else
                {
                    userSkill = userSkills.FirstOrDefault(userSkill => userSkill.Skill.Id == skill.Id);
                    userSkill.LevelOfSkill++;
                }

                user.UserSkills.Add(userSkill);
            }

            if (user != null)
            {
                await _unitOfWork.UserRepository.UpdateUser(user);
            }
        }

        private async Task UpdateUserCourses(User user)
        {
            var allCourses = (await _unitOfWork.UserCoursesRepository.GetAllUserCourse()).Where(user => user.User.Id == user.Id);
            foreach (var userCourse in allCourses)
            {
                var course = (await _unitOfWork.CourseRepository.GetCourse(userCourse.Course.Id)).ToDTO();
                int percent = GetPercent(course, user.ToDTO());
                userCourse.Percent = percent;
                userCourse.IsFinished = percent == 100;
                await UpdateUserCourse(userCourse.ToDTO());

                if (userCourse.IsFinished)
                {
                    var newCourse = (await _unitOfWork.CourseRepository.GetCourse(userCourse.Course.Id));
                    var newUser = (await _unitOfWork.UserRepository.GetUser(user.Id));
                    await UpdateSkills(newUser, newCourse);
                }
            }
        }

        private int GetPercent(CourseDTO courseDTO, UserDTO user)
        {
            int result = 0;
            if (courseDTO == null || user == null)
            {
                return result;
            }

            int def = 1;
            double percentForOneMaterial;
            if (courseDTO.Materials.Count() == 0)
            {
                percentForOneMaterial = (double)100 / def;
            }
            else
            {
                percentForOneMaterial = (double)100 / courseDTO.Materials.Count();
            }

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
