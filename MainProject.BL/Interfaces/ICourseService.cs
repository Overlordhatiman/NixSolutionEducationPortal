namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface ICourseService
    {
        public Task<CourseDTO> AddCourse(CourseDTO course);

        public Task<CourseDTO> UpdateCourse(int id, CourseDTO course);

        public List<CourseDTO> GetAllCourse();

        public Task<bool> DeleteCourse(int id);
    }
}
