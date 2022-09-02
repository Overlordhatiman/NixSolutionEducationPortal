namespace MainProject.BL.DTO
{
    public class UserSkillDTO
    {
        public int Id { get; set; }

        public int LevelOfSkill { get; set; }

        public SkillDTO Skill { get; set; }

        public UserDTO User { get; set; }

        public override string? ToString()
        {
            return Id.ToString() + "\t" + LevelOfSkill.ToString() + "\t";
        }
    }
}
