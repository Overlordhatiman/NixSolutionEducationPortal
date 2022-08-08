namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CourseDTO AddCourse(CourseDTO course)
        {
            this.unitOfWork.CourseRepository.AddCourse(course.ToModel());
            this.unitOfWork.Save();

            return course;
        }

        public bool DeleteCourse(int id)
        {
            bool result = this.unitOfWork.CourseRepository.DeleteCourse(id);
            this.unitOfWork.Save();

            return result;
        }

        public List<CourseDTO> GetAllCourse()
        {
            List<CourseDTO> courses = new List<CourseDTO>();
            foreach (var item in this.unitOfWork.CourseRepository.GetAllCourse())
            {
                courses.Add(item.ToDTO());
            }

            return courses;
        }

        public CourseDTO UpdateCourse(int id, CourseDTO course)
        {
            this.unitOfWork.CourseRepository.UpdateCourse(id, course.ToModel());
            this.unitOfWork.Save();

            return course;
        }
    }
}
