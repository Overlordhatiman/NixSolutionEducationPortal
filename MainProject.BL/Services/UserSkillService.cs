namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions.Mapping;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;
    using System.Collections.Generic;

    public class UserSkillService : IUserSkill
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserSkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserSkillDTO> AddUserSkill(UserSkillDTO userSkill)
        {
            await _unitOfWork.UserSkillsRepository.AddUserSkill(userSkill.ToModel());

            return userSkill;
        }

        public async Task<bool> DeleteUserSkill(int id)
        {
            var result = await _unitOfWork.UserSkillsRepository.DeleteUserSkill(id);

            return result != null;
        }

        public async Task<IEnumerable<UserSkillDTO>> GetAllUserSkill()
        {
            return (await _unitOfWork.UserSkillsRepository.GetAllUserSkill()).Select(x => x.ToDTO());
        }

        public async Task<UserSkillDTO> GetUserSkill(int id)
        {
            return UserSkillMapping.ToDTO(await _unitOfWork.UserSkillsRepository.GetUserSkill(id));
        }

        public async Task<UserSkillDTO> UpdateUserSkill(UserSkillDTO userSkill)
        {
            await _unitOfWork.UserSkillsRepository.UpdateUserSkill(userSkill.ToModel());

            return userSkill;
        }
    }
}
