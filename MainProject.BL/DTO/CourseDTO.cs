namespace MainProject.BL.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public List<MaterialsDTO>? Materials { get; set; }

        public List<SkillDTO>? Skills { get; set; }
    }
}
