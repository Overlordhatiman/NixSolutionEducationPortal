namespace MainProject.UI.Managed
{
    using FluentValidation.Results;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.UI.Validation;
    using Microsoft.Extensions.DependencyInjection;

    public class CourseCRUD
    {
        private ServiceProvider _service;
        private CourseValidation _courseValidation;

        public CourseCRUD(ServiceProvider service)
        {
            this._service = service;
            _courseValidation = new CourseValidation();
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
            var collection = _service.GetRequiredService<ICourseService>().GetAllCourse();

            foreach (var item in collection)
            {
                Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Description + "\t");
                foreach (var mat in item.Materials)
                {
                    Console.WriteLine(mat.Name);
                }
                Console.WriteLine("---------");
                foreach (var skill in item.Skills)
                {
                    Console.WriteLine(skill.Name);
                }
            }

            Console.ReadKey();
        }


        private int GetId()
        {
            Console.WriteLine("Input ID");
            int id;
            Int32.TryParse(Console.ReadLine(), out id);

            return id;
        }
        private CourseDTO GetCourse()
        {
            Console.WriteLine("Input ID");
            int id;
            Int32.TryParse(Console.ReadLine(), out id);

            Console.WriteLine("Input Name");
            string s = Console.ReadLine();

            Console.WriteLine("Input Description");
            string des = Console.ReadLine();

            CourseDTO course = new CourseDTO
            {
                Id = id,
                Name = s,
                Description = des
            };

            Console.WriteLine("Input number of materials");
            int number;
            Int32.TryParse(Console.ReadLine(), out number);

            List<MaterialsDTO> materials = new List<MaterialsDTO>();
            for (int i = 0; i < number; i++)
            {
                materials.Add(MaterialsCRUD.GetMaterials());
            }
            course.Materials = materials;

            Console.WriteLine("Input number of skills");
            Int32.TryParse(Console.ReadLine(), out number);
            int select;
            int idOfSkill;

            List<SkillDTO> skills = new List<SkillDTO>();
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("(1)Create or (2)Select");
                Int32.TryParse(Console.ReadLine(), out select);

                if(select == 1)
                {
                    skills.Add(SkillCRUD.GetSkill());
                }

                if (select == 2)
                {
                    Console.WriteLine("input id of skill");
                    Int32.TryParse(Console.ReadLine(), out idOfSkill);

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
            _service.GetRequiredService<ICourseService>().AddCourse(course);
        }

        private void UpdateCourse(CourseDTO course)
        {
            if (course == null)
            {
                return;
            }
            _service.GetRequiredService<ICourseService>().UpdateCourse(course.Id, course);
        }

        private void DeleteCourse(int id)
        {
            _service.GetRequiredService<IMaterialsService>().DeleteMaterial(id);
        }
    }
}
