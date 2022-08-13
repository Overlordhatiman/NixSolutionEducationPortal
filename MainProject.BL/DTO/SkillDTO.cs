namespace MainProject.BL.DTO
{
    public class SkillDTO
    {
        public int Id { get; set; } = 0;

        public string? Name { get; set; }

        public override string? ToString()
        {
            return Id.ToString() + "\t" + Name + "\t";
        }
    }
}
