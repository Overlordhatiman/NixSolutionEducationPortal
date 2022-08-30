namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions.Mapping;
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
            _unitOfWork.SkillRepository.Add(skill.ToModel());

            return skill;
        }

        public bool DeleteSkill(int id)
        {
            var result = _unitOfWork.SkillRepository.Delete(id);

            return result;
        }

        public List<SkillDTO> GetAllSkill()
        {
            List<SkillDTO> skills = new List<SkillDTO>();
            foreach (var skill in _unitOfWork.SkillRepository.GetAll())
            {
                skills.Add(skill.ToDTO());
            }

            return skills;
        }

        public SkillDTO UpdateSkill(SkillDTO skill)
        {
            _unitOfWork.SkillRepository.Update(skill.ToModel());

            return skill;
        }

        public SkillDTO GetSkill(int id)
        {
            return _unitOfWork.SkillRepository.GetById(id).ToDTO();
        }
    }
}
