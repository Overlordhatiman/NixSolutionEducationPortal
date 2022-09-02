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
            UserDTO user = _userController.GetUser();

            int percent = GetPercent(courseDTO);
            UserCourseDTO userCourse = new UserCourseDTO
            {
                IsFinished = 100 == percent,
                Percent = percent,
                Course = courseDTO,
                User = user,
            };

            if (percent == 100)
            {
                UpdateSkills(user, courseDTO);
            }

            _userCourseService.AddUserCourse(userCourse);
        }

        public void UpdateMaterials()
        {
            foreach (var item in _userCourseService.GetUserCourseForUser(_userController.IdUser))
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

            MaterialsDTO material = _materialService.GetMaterials(id);

            int userCourseId = _userCourseService.GetUserCourseForUser(_userController.IdUser).FirstOrDefault(course => course.Course.Id == courseDTO.Id).Id;

            UserDTO user = _userController.GetUser();

            if (!user.Materials.Contains(material))
            {
                user.Materials.Add(material);
                _userController.UpdateUser(user);
            }

            UpdateUserCourse(courseDTO, user, userCourseId);
        }

        public void OutputUserCourse()
        {
            foreach (var item in _userCourseService.GetUserCourseForUser(_userController.IdUser))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        private void UpdateUserCourse(CourseDTO courseDTO, UserDTO user, int id)
        {
            int percent = GetPercent(courseDTO);
            UserCourseDTO userCourse = new UserCourseDTO
            {
                Id = id,
                IsFinished = 100 == percent,
                Percent = percent,
                Course = courseDTO,
                User = user
            };

            if (percent == 100)
            {
                UpdateSkills(user, courseDTO);
            }

            _userCourseService.UpdateUserCourse(userCourse);
        }

        private void UpdateSkills(UserDTO user, CourseDTO course)
        {
            foreach (var skill in course.Skills)
            {
                if (user.UserSkills.Exists(x => x.Skill.Id == skill.Id))
                {
                    UserSkillDTO userSkill = user.UserSkills.Find(x => x.Skill.Id == skill.Id);
                    userSkill.LevelOfSkill++;
                    int index = user.UserSkills.FindIndex(x => x.Skill.Id == skill.Id);
                    user.UserSkills[index] = userSkill;
                }
                else
                {
                    UserSkillDTO userSkill = new UserSkillDTO
                    {
                        LevelOfSkill = 0,
                        Skill = skill,
                        User = user,
                    };

                    user.UserSkills.Add(userSkill);
                }
            }

            _userController.UpdateUser(user);
        }

        private int GetPercent(CourseDTO courseDTO)
        {
            int result = 0;
            double percentForOneMaterial = (double)100 / courseDTO.Materials.Count;
            UserDTO user = _userController.GetUser();

            foreach (var course in courseDTO.Materials)
            {
                foreach (var material in user.Materials)
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
