namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Models;

    public static class UserMapping
    {
        public static UserDTO ToDTO(this User user)
        {
            if (user == null)
            {
                return new UserDTO();
            }

            List<UserSkillDTO> userSkills = new List<UserSkillDTO>();
            List<MaterialsDTO> materials = new List<MaterialsDTO>();
            List<UserCourseDTO> userCourses = new List<UserCourseDTO>();

            foreach (var userSkill in user.UserSkills)
            {
                userSkills.Add(userSkill.ToDTO());
            }

            foreach (var material in user.Materials)
            {
                materials.Add(material.ToDTO());
            }

            foreach (var userCourse in user.UserCourses)
            {
                userCourses.Add(userCourse.ToDTO());
            }

            return new UserDTO
            {
                Id = user.Id,
                Mail = user.Mail,
                Password = user.Password,
                Materials = materials,
                UserCourses = userCourses,
                UserSkills = userSkills,
            };
        }

        public static User ToModel(this UserDTO user)
        {
            if (user == null)
            {
                return new User();
            }

            List<UserSkill> userSkills = new List<UserSkill>();
            List<Materials> materials = new List<Materials>();
            List<UserCourse> userCourses = new List<UserCourse>();

            foreach (var userSkill in user.UserSkills)
            {
                userSkills.Add(userSkill.ToModel());
            }

            foreach (var material in user.Materials)
            {
                materials.Add(material.ToModel());
            }

            foreach (var userCourse in user.UserCourses)
            {
                userCourses.Add(userCourse.ToModel());
            }

            return new User
            {
                Id = user.Id,
                Mail = user.Mail,
                Password = user.Password,
                Materials = materials,
                UserCourses = userCourses,
                UserSkills = userSkills,
            };
        }
    }
}
