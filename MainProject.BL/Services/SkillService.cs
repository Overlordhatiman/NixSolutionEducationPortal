namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork unitOfWork;

        public SkillService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public SkillDTO AddSkill(SkillDTO skill)
        {
            this.unitOfWork.SkillRepository.AddSkill(skill.ToModel());
            this.unitOfWork.Save();

            return skill;
        }

        public bool DeleteSkill(int id)
        {
            bool result = this.unitOfWork.SkillRepository.DeleteSkill(id);
            this.unitOfWork.Save();

            return result;
        }

        public List<SkillDTO> GetAllSkill()
        {
            List<SkillDTO> skills = new List<SkillDTO>();
            foreach (var item in this.unitOfWork.SkillRepository.GetAllSkill())
            {
                skills.Add(item.ToDTO());
            }

            return skills;
        }

        public SkillDTO UpdateSkill(int id, SkillDTO skill)
        {
            this.unitOfWork.SkillRepository.UpdateSkill(id, skill.ToModel());
            this.unitOfWork.Save();

            return skill;
        }
    }
}
