namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions.Mapping;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseDTO> AddCourse(CourseDTO course)
        {
            if (course == null)
            {
                return null;
            }

            await _unitOfWork.CourseRepository.AddCourse(course.ToModel());

            return course;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            var result = await _unitOfWork.CourseRepository.DeleteCourse(id);

            return result != null;
        }

        public async Task<List<CourseDTO>> GetAllCourse()
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            foreach (var course in await _unitOfWork.CourseRepository.GetAllCourse())
            {
                courses.Add(course.ToDTO());
            }

            return courses;
        }

        public async Task<CourseDTO> UpdateCourse(CourseDTO course)
        {
            await _unitOfWork.CourseRepository.UpdateCourse(course.ToModel());

            return course;
        }

        public async Task<CourseDTO> GetCourse(int id)
        {
            return CourseMapping.ToDTO(await _unitOfWork.CourseRepository.GetCourse(id));
        }
    }
}
