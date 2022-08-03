using MainProject.BL.DTO;

namespace MainProject.BL.Interfaces
{
    public interface ICourseService
    {
        public CourseDTO AddCourse(CourseDTO course);
        public CourseDTO UpdateCourse(int id, CourseDTO course);
        public List<CourseDTO> GetAllCourse();
        public bool DeleteCourse(CourseDTO course);
    }
}
