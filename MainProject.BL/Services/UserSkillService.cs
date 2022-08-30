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

        public UserSkillDTO AddUserSkill(UserSkillDTO userSkill)
        {
            _unitOfWork.UserSkillsRepository.Add(userSkill.ToModel());

            return userSkill;
        }

        public bool DeleteUserSkill(int id)
        {
            var result = _unitOfWork.UserSkillsRepository.Delete(id);

            return result != null;
        }

        public List<UserSkillDTO> GetAllUserSkill()
        {
            List<UserSkillDTO> userSkills = new List<UserSkillDTO>();

            foreach (var userSkill in _unitOfWork.UserSkillsRepository.GetAll())
            {
                userSkills.Add(userSkill.ToDTO());
            }

            return userSkills;
        }

        public UserSkillDTO GetUserSkill(int id)
        {
            return _unitOfWork.UserSkillsRepository.GetById(id).ToDTO();
        }

        public UserSkillDTO UpdateUserSkill(UserSkillDTO userSkill)
        {
            _unitOfWork.UserSkillsRepository.Update(userSkill.ToModel());

            return userSkill;
        }
    }
}
