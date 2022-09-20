namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface ICourseService
    {
        public Task<CourseDTO> AddCourse(CourseDTO course);

        public Task<CourseDTO> UpdateCourse(CourseDTO course);

        public Task<IEnumerable<CourseDTO>> GetAllCourse();

        public Task<bool> DeleteCourse(int id);

        public Task<CourseDTO> GetCourse(int id);
    }
}
