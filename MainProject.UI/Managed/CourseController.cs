namespace MainProject.UI.Managed
{
    using FluentValidation.Results;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.UI.Validation;

    public class CourseController
    {
        private ICourseService _courseService;

        private CourseValidation _courseValidation;

        private SkillController _skillCRUD;

        private MaterialsController _materialCRUD;

        public CourseController(ICourseService service, SkillController skill, MaterialsController materialCRUD)
        {
            _courseService = service;
            _courseValidation = new CourseValidation();
            _skillCRUD = skill;
            _materialCRUD = materialCRUD;
        }

        public void CreateCourse()
        {
            CreateCourse(GetCourse());
        }

        public void UpdateCourse()
        {
            Console.WriteLine("Intput ID that you want to change");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            UpdateCourse(GetCourse(), id);
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
            string name = Console.ReadLine();

            Console.WriteLine("Input Description");
            string description = Console.ReadLine();

            CourseDTO course = new CourseDTO
            {
                Name = name,
                Description = description
            };

            Console.WriteLine("Input number of materials");
            int number;
            int select;
            int idOfSkillOrMaterial;
            int.TryParse(Console.ReadLine(), out number);

            course.Materials = new List<MaterialsDTO>();
            for (int i = 0; i < number; i++)
            {
                MaterialsDTO material = _materialCRUD.GetMaterials();
                course.Materials.Add(material);

                Console.WriteLine("(1)Create or (2)Select");
                int.TryParse(Console.ReadLine(), out select);

                if (select == 1)
                {
                    MaterialsDTO materials = _materialCRUD.GetMaterials();
                    course.Materials.Add(materials);
                    SaveMaterials(materials);
                }

                if (select == 2)
                {
                    _materialCRUD.OutputMaterials();
                    Console.WriteLine("Input id of material");
                    int.TryParse(Console.ReadLine(), out idOfSkillOrMaterial);

                    MaterialsDTO materials = _materialCRUD.GetMaterialById(idOfSkillOrMaterial);
                    materials.Id = course.Id;

                    course.Materials.Add(materials);
                    _materialCRUD.SaveMaterialAfterUpdate(materials);
                }
            }

            Console.WriteLine("Input number of skills");
            int.TryParse(Console.ReadLine(), out number);

            course.Skills = new List<SkillDTO>();
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("(1)Create or (2)Select");
                int.TryParse(Console.ReadLine(), out select);

                if (select == 1)
                {
                    SkillDTO skill = _skillCRUD.GetSkillFromConsole();
                    course.Skills.Add(skill);
                    SaveSkills(skill);
                }

                if (select == 2)
                {
                    _skillCRUD.OutputSkills();
                    Console.WriteLine("Input id of skill");
                    int.TryParse(Console.ReadLine(), out idOfSkillOrMaterial);

                    SkillDTO skill = _skillCRUD.GetSkillById(idOfSkillOrMaterial);
                    skill.Id = course.Id;

                    course.Skills.Add(skill);
                    _skillCRUD.SaveSkillAfterUpdate(skill);
                }
            }

            return Validate(course);
        }

        private CourseDTO Validate(CourseDTO course)
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

        private void UpdateCourse(CourseDTO course, int id)
        {
            if (course == null)
            {
                return;
            }

            course.Id = id;
            _courseService.UpdateCourse(course);
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

        private void SaveMaterials(MaterialsDTO materials)
        {
            if (materials == null)
            {
                return;
            }

            _materialCRUD.SaveMaterials(materials);
        }
    }
}
