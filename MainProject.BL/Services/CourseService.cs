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

        public CourseDTO AddCourse(CourseDTO course)
        {
            _unitOfWork.CourseRepository.AddCourse(course.ToModel());

            return course;
        }

        public bool DeleteCourse(int id)
        {
            var result = _unitOfWork.CourseRepository.DeleteCourse(id);

            return result != null;
        }

        public List<CourseDTO> GetAllCourse()
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            foreach (var course in _unitOfWork.CourseRepository.GetAllCourse())
            {
                courses.Add(course.ToDTO());
            }

            return courses;
        }

        public CourseDTO UpdateCourse(CourseDTO course)
        {
            _unitOfWork.CourseRepository.UpdateCourse(course.ToModel());

            return course;
        }

        public CourseDTO GetCourse(int id)
        {
            return _unitOfWork.CourseRepository.GetCourse(id).ToDTO();
        }
    }
}
