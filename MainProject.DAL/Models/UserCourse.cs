namespace MainProject.DAL.Models
{
    public class UserCourse
    {
        public int Id { get; set; }

        public Course? Course { get; set; }

        public User? User { get; set; }

        public bool IsFinished { get; set; }

        public int Percent { get; set; }
    }
}
