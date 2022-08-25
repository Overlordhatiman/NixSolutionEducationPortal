namespace MainProject.UI.Managed
{
    using FluentValidation.Results;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.UI.Validation;

    public class SkillController
    {
        private ISkillService _skillService;

        private SkillValidation _skillValidation;

        public SkillController(ISkillService service)
        {
            _skillService = service;
            _skillValidation = new SkillValidation();
        }

        public SkillDTO GetSkillFromConsole()
        {
            Console.WriteLine("Input Name");
            string s = Console.ReadLine();

            SkillDTO skill = new SkillDTO
            {
                Name = s,
            };

            return Validate(skill);
        }

        public SkillDTO GetSkillById(int id)
        {
            return _skillService.GetSkill(id);
        }

        public void CreateSkill()
        {
            CreateSkill(GetSkillFromConsole());
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
            OutputSkills();

            int id = GetId();
            Console.WriteLine("Current object");
            Console.WriteLine(_skillService.GetSkill(id));
            SkillDTO skill = GetSkillFromConsole();
            skill.Id = id;

            UpdateSkill(skill);
        }

        public void SaveSkillAfterUpdate(SkillDTO skill)
        {
            UpdateSkill(skill);
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

        private SkillDTO Validate(SkillDTO skill)
        {
            ValidationResult validationResult = _skillValidation.Validate(skill);

            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
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

            _skillService.UpdateSkill(skill);
        }

        private void DeleteSkill(int id)
        {
            _skillService.DeleteSkill(id);
        }
    }
}
