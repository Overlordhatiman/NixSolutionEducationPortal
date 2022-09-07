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
            await _unitOfWork.UserSkillsRepository.Add(userSkill.ToModel());

            return userSkill;
        }

        public async Task<bool> DeleteUserSkill(int id)
        {
            var result = await _unitOfWork.UserSkillsRepository.Delete(id);

            return result != null;
        }

        public async Task<List<UserSkillDTO>> GetAllUserSkill()
        {
            List<UserSkillDTO> userSkills = new List<UserSkillDTO>();

            foreach (var userSkill in await _unitOfWork.UserSkillsRepository.GetAll())
            {
                userSkills.Add(userSkill.ToDTO());
            }

            return userSkills;
        }

        public async Task<UserSkillDTO> GetUserSkill(int id)
        {
            return UserSkillMapping.ToDTO(await _unitOfWork.UserSkillsRepository.GetById(id));
        }

        public async Task<UserSkillDTO> UpdateUserSkill(UserSkillDTO userSkill)
        {
            await _unitOfWork.UserSkillsRepository.Update(userSkill.ToModel());

            return userSkill;
        }
    }
}
