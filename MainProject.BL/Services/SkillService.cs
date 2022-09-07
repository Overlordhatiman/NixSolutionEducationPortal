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
            await _unitOfWork.SkillRepository.Add(skill.ToModel());

            return skill;
        }

        public async Task<bool> DeleteSkill(int id)
        {
            var result = await _unitOfWork.SkillRepository.Delete(id);

            return result;
        }

        public async Task<List<SkillDTO>> GetAllSkill()
        {
            List<SkillDTO> skills = new List<SkillDTO>();
            foreach (var skill in await _unitOfWork.SkillRepository.GetAll())
            {
                skills.Add(skill.ToDTO());
            }

            return skills;
        }

        public async Task<SkillDTO> UpdateSkill(SkillDTO skill)
        {
            await _unitOfWork.SkillRepository.Update(skill.ToModel());

            return skill;
        }

        public async Task<SkillDTO> GetSkill(int id)
        {
            return SkillMapping.ToDTO(await _unitOfWork.SkillRepository.GetById(id));
        }
    }
}
