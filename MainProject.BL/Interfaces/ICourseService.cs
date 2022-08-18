namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface ICourseService
    {
        public CourseDTO AddCourse(CourseDTO course);

        public CourseDTO UpdateCourse(CourseDTO course);

        public List<CourseDTO> GetAllCourse();

        public bool DeleteCourse(int id);

        public CourseDTO GetCourse(int id);
    }
}
