namespace MainProject.UI.Managed
{
    using FluentValidation.Results;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.UI.Validation;

    public class CourseCRUD
    {
        private ICourseService _courseService;

        private CourseValidation _courseValidation;

        private SkillCRUD _skillCRUD;

        public CourseCRUD(ICourseService service, SkillCRUD skill)
        {
            _courseService = service;
            _courseValidation = new CourseValidation();
            _skillCRUD = skill;
        }

        public void CreateCourse()
        {
            CreateCourse(GetCourse());
        }

        public void UpdateCourse()
        {
            UpdateCourse(GetCourse());
        }

        public void DeleteCourse()
        {
            DeleteCourse(GetId());
        }

        public void OutputCourse()
        {
            Console.WriteLine("Course");
            var collection = _courseService.GetAllCourse();

            foreach (var course in collection)
            {
                Console.WriteLine(course);
            }

            Console.ReadKey();
        }

        private int GetId()
        {
            Console.WriteLine("Input ID");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            return id;
        }

        private CourseDTO GetCourse()
        {
            Console.WriteLine("Input Name");
            string s = Console.ReadLine();

            Console.WriteLine("Input Description");
            string des = Console.ReadLine();

            CourseDTO course = new CourseDTO
            {
                Name = s,
                Description = des
            };

            Console.WriteLine("Input number of materials");
            int number;
            int.TryParse(Console.ReadLine(), out number);

            List<MaterialsDTO> materials = new List<MaterialsDTO>();
            for (int i = 0; i < number; i++)
            {
                materials.Add(MaterialsCRUD.GetMaterials());
            }

            course.Materials = materials;

            Console.WriteLine("Input number of skills");
            int.TryParse(Console.ReadLine(), out number);
            int select;
            int idOfSkill;

            List<SkillDTO> skills = new List<SkillDTO>();
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("(1)Create or (2)Select");
                int.TryParse(Console.ReadLine(), out select);

                if (select == 1)
                {
                    SkillDTO skill = SkillCRUD.GetSkill();
                    skills.Add(skill);
                    SaveSkills(skill);
                }

                if (select == 2)
                {
                    Console.WriteLine("input id of skill");
                    int.TryParse(Console.ReadLine(), out idOfSkill);

                    skills.Add(SkillCRUD.GetSkillById(idOfSkill));
                }
            }

            course.Skills = skills;

            return ValidateCourse(course);
        }

        private CourseDTO ValidateCourse(CourseDTO course)
        {
            ValidationResult validationResult = _courseValidation.Validate(course);

            foreach (var item in validationResult.Errors)
            {
                Console.WriteLine(item.ErrorMessage);
            }

            Console.ReadKey();

            if (validationResult.IsValid)
            {
                return course;
            }

            return null;
        }

        private void CreateCourse(CourseDTO course)
        {
            if (course == null)
            {
                return;
            }

            _courseService.AddCourse(course);
        }

        private void UpdateCourse(CourseDTO course)
        {
            Console.WriteLine("Intput ID that you want to change");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            if (course == null)
            {
                return;
            }

            _courseService.UpdateCourse(id, course);
        }

        private void DeleteCourse(int id)
        {
            _courseService.DeleteCourse(id);
        }

        private void SaveSkills(SkillDTO skill)
        {
            if (skill == null)
            {
                return;
            }

            _skillCRUD.SaveSkills(skill);
        }
    }
}
