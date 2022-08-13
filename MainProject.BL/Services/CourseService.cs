namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseDTO> AddCourse(CourseDTO course)
        {
            _unitOfWork.CourseRepository.AddCourse(course.ToModel());
            _unitOfWork.Save();

            return course;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            bool result = _unitOfWork.CourseRepository.DeleteCourse(id);
            await _unitOfWork.Save();

            return result;
        }

        public List<CourseDTO> GetAllCourse()
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            foreach (var item in _unitOfWork.CourseRepository.GetAllCourse())
            {
                courses.Add(item.ToDTO());
            }

            return courses;
        }

        public async Task<CourseDTO> UpdateCourse(int id, CourseDTO course)
        {
            _unitOfWork.CourseRepository.UpdateCourse(id, course.ToModel());
            await _unitOfWork.Save();

            return course;
        }
    }
}
