namespace MainProject.UI.Managed
{
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.BL.Services;

    public class UserCourseController
    {
        private UserController _userController;

        private IUserCourse _userCourseService;

        private IUserSkill _userSkillService;

        private ICourseService _courseService;

        public UserCourseController(UserController userController, IUserCourse userCourseService, IUserSkill userSkillService, ICourseService courseService)
        {
            _userController = userController ?? throw new ArgumentNullException(nameof(userController));
            _userCourseService = userCourseService ?? throw new ArgumentNullException(nameof(userCourseService));
            _userSkillService = userSkillService ?? throw new ArgumentNullException(nameof(userSkillService));
            _courseService = courseService;
        }

        public void StartCourse(int id)
        {
            CourseDTO courseDTO = _courseService.GetCourse(id);

            UserCourseDTO userCourse = new UserCourseDTO
            {
                IsFinished = false,
                Percent = GetPercent(courseDTO),
                Course = courseDTO,
            };

            _userCourseService.AddUserCourse(userCourse);
        }

        public void UpdateSkill()
        {
        }

        private int GetPercent(CourseDTO courseDTO)
        {
            int result = 0;
            double percentForOneMaterial = (double)100 / courseDTO.Materials.Count;

            foreach (var item in courseDTO.Materials)
            {
                var c = _userController.CurrentUser.Materials.FirstOrDefault(item);
                if (c != null)
                {
                    result += (int)percentForOneMaterial;
                }
            }

            return result;
        }
    }
}
