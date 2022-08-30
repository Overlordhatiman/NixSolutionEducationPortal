namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Models;

    public static class UserSkillMapping
    {
        public static UserSkillDTO ToDTO(this UserSkill userSkill)
        {
            if (userSkill == null)
            {
                return new UserSkillDTO();
            }

            return new UserSkillDTO
            {
                Id = userSkill.Id,
                LevelOfSkill = userSkill.LevelOfSkill,
            };
        }

        public static UserSkill ToModel(this UserSkillDTO userSkill)
        {
            if (userSkill == null)
            {
                return new UserSkill();
            }

            return new UserSkill
            {
                Id = userSkill.Id,
                LevelOfSkill = userSkill.LevelOfSkill,
            };
        }
    }
}
