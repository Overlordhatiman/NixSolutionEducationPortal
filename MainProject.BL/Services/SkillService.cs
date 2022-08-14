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
            var result = await _unitOfWork.SkillRepository.DeleteSkill(id);
            await _unitOfWork.Save();

            return result;
        }

        public async Task<List<SkillDTO>> GetAllSkill()
        {
            List<SkillDTO> skills = new List<SkillDTO>();
            foreach (var skill in await _unitOfWork.SkillRepository.GetAllSkill())
            {
                skills.Add(skill.ToDTO());
            }

            return skills;
        }

        public async Task<SkillDTO> UpdateSkill(SkillDTO skill)
        {
            await _unitOfWork.SkillRepository.UpdateSkill(skill.ToModel());
            await _unitOfWork.Save();

            return skill;
        }

        public async Task<SkillDTO> GetSkill(int id)
        {
            var skill = await _unitOfWork.SkillRepository.GetSkill(id);

            return skill.ToDTO();
        }
    }
}
