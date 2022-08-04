using FluentValidation.Results;
using MainProject.BL.DTO;
using MainProject.BL.Interfaces;
using MainProject.UI.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.UI.Managed
{
    public class SkillCRUD
    {
        private static ISkillService _skillService;

        private static SkillValidation _skillValidation;

        public SkillCRUD(ISkillService service)
        {
            _skillService = service;
            _skillValidation = new SkillValidation();
        }

        public void CreateSkill()
        {
            CreateSkill(GetSkill());
        }

        public void UpdateSkill()
        {
            UpdateSkill(GetSkill());
        }

        public void DeleteSkill()
        {
            DeleteSkill(GetId());
        }

        public void OutputMaterials()
        {
            Console.WriteLine("Skills");
            var collection = _skillService.GetAllSkill();

            foreach (var item in collection)
            {
                Console.WriteLine(item.Id + "\t" + item.Name);
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
        public static SkillDTO GetSkill()
        {
            Console.WriteLine("Input ID");
            int id;
            Int32.TryParse(Console.ReadLine(), out id);

            Console.WriteLine("Input Name");
            string s = Console.ReadLine();

            SkillDTO skill = new SkillDTO
            {
                Id = id,
                Name = s,
            };

            return ValidateMaterial(skill);
        }

        public static SkillDTO GetSkillById(int id)
        {
            var collection = _skillService.GetAllSkill();

            return collection.Find(x => x.Id == id);
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
