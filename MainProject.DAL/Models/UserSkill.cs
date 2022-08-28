namespace MainProject.DAL.Models
{
    public class UserSkill
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int SkillId { get; set; }

        public User User { get; set; }

        public Skill Skill { get; set; }

        public int LevelOfSkill { get; set; }
    }
}
