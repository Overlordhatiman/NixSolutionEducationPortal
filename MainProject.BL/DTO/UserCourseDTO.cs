namespace MainProject.BL.DTO
{
    public class UserCourseDTO
    {
        public int Id { get; set; }

        public bool IsFinished { get; set; }

        public int Percent { get; set; }

        public CourseDTO? Course { get; set; }

        public UserDTO? User { get; set; }

        public override string? ToString()
        {
            return "\t Is finished: " + IsFinished + "\t Percent: " + Percent.ToString() + "\t" + Course.Id.ToString();
        }
    }
}
