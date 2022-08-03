using MainProject.BL.DTO;
using MainProject.BL.Extentions;
using MainProject.BL.Interfaces;
using MainProject.DAL.Interfaces;

namespace MainProject.BL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public CourseDTO AddCourse(CourseDTO course)
        {
            _unitOfWork.CourseRepository.AddCourse(course.ToModel());
            _unitOfWork.Save();

            return course;
        }

        public bool DeleteCourse(CourseDTO course)
        {
            bool result = _unitOfWork.CourseRepository.DeleteCourse(course.ToModel());
            _unitOfWork.Save();

            return result;
        }

        public List<CourseDTO> GetAllCourse()
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            foreach (var item in _unitOfWork.CourseRepository.GetAllCourse())
            {
                courses.Add((item).ToDTO());
            }

            return courses;
        }

        public CourseDTO UpdateCourse(int id, CourseDTO course)
        {
            _unitOfWork.CourseRepository.UpdateCourse(id, (course).ToModel());
            _unitOfWork.Save();

            return course;
        }
    }
}
