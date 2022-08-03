using MainProject.BL.DTO;
using MainProject.BL.Extentions;
using MainProject.BL.Interfaces;
using MainProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.BL.Services
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SkillService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public SkillDTO AddSkill(SkillDTO skill)
        {
            _unitOfWork.SkillRepository.AddSkill(skill.ToModel());
            _unitOfWork.Save();

            return skill;
        }

        public bool DeleteSkill(SkillDTO skill)
        {
            bool result = _unitOfWork.SkillRepository.DeleteSkill((skill).ToModel());
            _unitOfWork.Save();

            return result;
        }

        public List<SkillDTO> GetAllSkill()
        {
            List<SkillDTO> skills = new List<SkillDTO>();
            foreach (var item in _unitOfWork.SkillRepository.GetAllSkill())
            {
                skills.Add((item).ToDTO());
            }

            return skills;
        }

        public SkillDTO UpdateSkill(int id, SkillDTO skill)
        {
            _unitOfWork.SkillRepository.UpdateSkill(id, (skill).ToModel());
            _unitOfWork.Save();

            return skill;
        }
    }
}
