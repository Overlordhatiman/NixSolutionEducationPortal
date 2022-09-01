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

        private IMaterialsService _materialService;

        public UserCourseController(UserController userController,
                                    IUserCourse userCourseService,
                                    IUserSkill userSkillService,
                                    ICourseService courseService,
                                    IMaterialsService materialsService)
        {
            _userController = userController ?? throw new ArgumentNullException(nameof(userController));
            _userCourseService = userCourseService ?? throw new ArgumentNullException(nameof(userCourseService));
            _userSkillService = userSkillService ?? throw new ArgumentNullException(nameof(userSkillService));
            _courseService = courseService;
            _materialService = materialsService;
        }

        public void StartCourseFromConsole()
        {
            foreach (var course in _courseService.GetAllCourse())
            {
                Console.WriteLine(course);
            }

            Console.WriteLine("Input ID of course");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            StartCourse(id);
        }

        public void StartCourse(int id)
        {
            CourseDTO courseDTO = _courseService.GetCourse(id);

            UserCourseDTO userCourse = new UserCourseDTO
            {
                IsFinished = false,
                Percent = GetPercent(courseDTO),
                Course = courseDTO,
                User = _userController.CurrentUser
            };

            _userCourseService.AddUserCourse(userCourse);
        }

        public void UpdateMaterials()
        {
            foreach (var item in _userCourseService
                                .GetAllUserCourse()
                                .Where(userCourse => userCourse.User.Id == _userController.CurrentUser.Id))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Select id of course");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            CourseDTO courseDTO = _courseService.GetCourse(id);

            Console.WriteLine(courseDTO);

            Console.WriteLine("Input id of material");

            int.TryParse(Console.ReadLine(), out id);

            _userController.CurrentUser.Materials.Add(_materialService.GetMaterials(id));
            _userController.UpdateUser(_userController.CurrentUser);

            UpdateUserCourse(courseDTO);
        }

        public void OutputUserCourse()
        {
            foreach (var item in _userCourseService.GetAllUserCourse())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        private void UpdateUserCourse(CourseDTO courseDTO)
        {
            int percent = GetPercent(courseDTO);
            UserCourseDTO userCourse = new UserCourseDTO
            {
                IsFinished = 100 == percent,
                Percent = percent,
                Course = courseDTO,
                User = _userController.CurrentUser
            };

            _userCourseService.UpdateUserCourse(userCourse);
        }

        private int GetPercent(CourseDTO courseDTO)
        {
            int result = 0;
            double percentForOneMaterial = (double)100 / courseDTO.Materials.Count;

            foreach (var course in courseDTO.Materials)
            {
                foreach (var material in _userController.CurrentUser.Materials)
                {
                    if (course.Id == material.Id)
                    {
                        result += (int)percentForOneMaterial;
                    }
                }
            }

            return result;
        }
    }
}
