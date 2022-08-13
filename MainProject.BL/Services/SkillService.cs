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

        public async Task<SkillDTO> AddSkill(SkillDTO skill)
        {
            _unitOfWork.SkillRepository.AddSkill(skill.ToModel());
            await _unitOfWork.Save();

            return skill;
        }

        public async Task<bool> DeleteSkill(int id)
        {
            var result = _unitOfWork.SkillRepository.DeleteSkill(id);
            await _unitOfWork.Save();

            return result;
        }

        public List<SkillDTO> GetAllSkill()
        {
            List<SkillDTO> skills = new List<SkillDTO>();
            foreach (var item in _unitOfWork.SkillRepository.GetAllSkill())
            {
                skills.Add(item.ToDTO());
            }

            return skills;
        }

        public async Task<SkillDTO> UpdateSkill(int id, SkillDTO skill)
        {
            _unitOfWork.SkillRepository.UpdateSkill(id, skill.ToModel());
            await _unitOfWork.Save();

            return skill;
        }
    }
}
