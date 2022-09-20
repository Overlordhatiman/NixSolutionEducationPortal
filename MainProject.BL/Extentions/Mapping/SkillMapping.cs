namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

    public static class SkillMapping
    {
        public static SkillDTO ToDTO(this Skill skill)
        {
            if (skill == null)
            {
                return new SkillDTO();
            }

            SkillDTO skillDTO = new SkillDTO
            {
                Id = skill.Id,
                Name = skill.Name,
            };

            return skillDTO;
        }

        public static Skill ToModel(this SkillDTO skill, IUnitOfWork unitOfWork)
        {
            if (skill == null)
            {
                return new Skill();
            }

            Skill skillModel;

            if (skill.Id != 0 && unitOfWork != null)
            {
                skillModel = unitOfWork.SkillRepository.GetById(skill.Id).Result;
                skillModel.Id = skill.Id;
                skillModel.Name = skill.Name;
            }
            else
            {
                skillModel = new Skill
                {
                    Id = skill.Id,
                    Name = skill.Name,
                };
            }

            return skillModel;
        }
    }
}
