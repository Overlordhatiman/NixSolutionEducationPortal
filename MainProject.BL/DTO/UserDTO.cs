namespace MainProject.BL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? Mail { get; set; }

        public string? Password { get; set; }

        public List<UserSkillDTO>? UserSkills { get; set; } = new List<UserSkillDTO>();

        public List<MaterialsDTO>? Materials { get; set; } = new List<MaterialsDTO>();

        public List<UserCourseDTO>? UserCourses { get; set; } = new List<UserCourseDTO>();
    }
}
