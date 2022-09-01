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

        public override string? ToString()
        {
            string result = string.Empty;

            result += Id.ToString() + "\t" + Mail + "\t" + Password + "\n";

            result += "User skills" + "\n";
            foreach (var item in UserSkills)
            {
                result += item + "\n";
            }

            result += "User's materials" + "\n";
            foreach (var item in Materials)
            {
                result += item + "\n";
            }

            result += "User course" + "\n";
            foreach (var item in UserCourses)
            {
                result += item + "\n";
            }

            return result;
        }
    }
}
