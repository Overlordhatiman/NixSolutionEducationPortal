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

        public static SkillDTO GetSkillFromConsole()
        {
            Console.WriteLine("Input Name");
            string s = Console.ReadLine();

            SkillDTO skill = new SkillDTO
            {
                Name = s,
            };

            return Validate(skill);
        }

        public static SkillDTO GetSkillById(int id)
        {
            var skills = _skillService.GetAllSkill();

            return skills.Result.Find(x => x.Id == id);
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
            int id = GetId();
            Console.WriteLine("Current object");
            Console.WriteLine(_skillService.GetSkill(id).Result);

            UpdateSkill(GetSkillFromConsole(), id).Wait();
        }

        public void DeleteSkill()
        {
            DeleteSkill(GetId());
        }

        public void OutputSkills()
        {
            Console.WriteLine("Skills");
            var skills = _skillService.GetAllSkill();

            foreach (var skill in skills.Result)
            {
                Console.WriteLine(skill);
            }

            Console.ReadKey();
        }

        private static SkillDTO Validate(SkillDTO skill)
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

        private async Task CreateSkill(SkillDTO skill)
        {
            if (skill == null)
            {
                return;
            }

            await _skillService.AddSkill(skill);
        }

        private async Task UpdateSkill(SkillDTO skill, int id)
        {
            if (skill == null)
            {
                return;
            }

            skill.Id = id;
            await _skillService.UpdateSkill(skill);
        }

        private async Task DeleteSkill(int id)
        {
            await _skillService.DeleteSkill(id);
        }
    }
}
