namespace MainProject.UI.Managed
{
    using FluentValidation.Results;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.UI.Validation;

    public class SkillCRUD
    {
        private static ISkillService _skillService;

        private static SkillValidation _skillValidation;

        public SkillCRUD(ISkillService service)
        {
            _skillService = service;
            _skillValidation = new SkillValidation();
        }

        public static SkillDTO GetSkill()
        {
            Console.WriteLine("Input Name");
            string s = Console.ReadLine();

            SkillDTO skill = new SkillDTO
            {
                Name = s,
            };

            return ValidateMaterial(skill);
        }

        public static SkillDTO GetSkillById(int id)
        {
            var collection = _skillService.GetAllSkill();

            return collection.Find(x => x.Id == id);
        }

        public void CreateSkill()
        {
            CreateSkill(GetSkill());
        }

        public void SaveSkills(SkillDTO skill)
        {
            if (skill == null)
            {
                return;
            }

            _skillService.AddSkill(skill);
        }

        public void UpdateSkill()
        {
            UpdateSkill(GetSkill());
        }

        public void DeleteSkill()
        {
            DeleteSkill(GetId());
        }

        public void OutputSkills()
        {
            Console.WriteLine("Skills");
            var skills = _skillService.GetAllSkill();

            foreach (var skill in skills)
            {
                Console.WriteLine(skill);
            }

            Console.ReadKey();
        }

        private static SkillDTO ValidateMaterial(SkillDTO skill)
        {
            ValidationResult validationResult = _skillValidation.Validate(skill);

            foreach (var item in validationResult.Errors)
            {
                Console.WriteLine(item.ErrorMessage);
            }

            Console.ReadKey();

            if (validationResult.IsValid)
            {
                return skill;
            }

            return null;
        }

        private int GetId()
        {
            Console.WriteLine("Input ID");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            return id;
        }

        private void CreateSkill(SkillDTO skill)
        {
            if (skill == null)
            {
                return;
            }

            _skillService.AddSkill(skill);
        }

        private void UpdateSkill(SkillDTO skill)
        {
            if (skill == null)
            {
                return;
            }

            _skillService.UpdateSkill(skill.Id, skill);
        }

        private void DeleteSkill(int id)
        {
            _skillService.DeleteSkill(id);
        }
    }
}
