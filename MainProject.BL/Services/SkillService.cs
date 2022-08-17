namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SkillDTO AddSkill(SkillDTO skill)
        {
            _unitOfWork.SkillRepository.AddSkill(skill.ToModel());

            return skill;
        }

        public bool DeleteSkill(int id)
        {
            var result = _unitOfWork.SkillRepository.DeleteSkill(id);

            return result;
        }

        public List<SkillDTO> GetAllSkill()
        {
            List<SkillDTO> skills = new List<SkillDTO>();
            foreach (var skill in _unitOfWork.SkillRepository.GetAllSkill())
            {
                skills.Add(skill.ToDTO());
            }

            return skills;
        }

        public SkillDTO UpdateSkill(SkillDTO skill)
        {
            _unitOfWork.SkillRepository.UpdateSkill(skill.ToModel());

            return skill;
        }

        public SkillDTO GetSkill(int id)
        {
            return _unitOfWork.SkillRepository.GetSkill(id).ToDTO();
        }
    }
}
