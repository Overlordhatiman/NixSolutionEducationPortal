namespace MainProject.BL.DTO
{
    public class SkillDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public override string? ToString()
        {
            return Name + "\t";
        }
    }
}
