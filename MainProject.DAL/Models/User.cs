namespace MainProject.DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Mail { get; set; }

        public string? Password { get; set; }

        public List<UserSkill>? UserSkills { get; set; } = new List<UserSkill>();

        public List<Materials>? Materials { get; set; } = new List<Materials>();

        public List<UserCourse>? UserCourses { get; set; } = new List<UserCourse>();
    }
}
