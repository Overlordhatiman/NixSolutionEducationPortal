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

        public async Task<SkillDTO> AddSkill(SkillDTO skill)
        {
            await _unitOfWork.SkillRepository.AddSkill(skill.ToModel(_unitOfWork));

            return skill;
        }

        public async Task<bool> DeleteSkill(int id)
        {
            var result = await _unitOfWork.SkillRepository.DeleteSkill(id);

            return result;
        }

        public async Task<IEnumerable<SkillDTO>> GetAllSkill()
        {
            return (await _unitOfWork.SkillRepository.GetAllSkill()).Select(x => x.ToDTO());
        }

        public async Task<SkillDTO> UpdateSkill(SkillDTO skill)
        {
            await _unitOfWork.SkillRepository.UpdateSkill(skill.ToModel(_unitOfWork));

            return skill;
        }

        public async Task<SkillDTO> GetSkill(int id)
        {
            return SkillMapping.ToDTO(await _unitOfWork.SkillRepository.GetSkill(id));
        }
    }
}
