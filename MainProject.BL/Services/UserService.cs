namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions.Mapping;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDTO> AddUser(UserDTO user)
        {
            await _unitOfWork.UserRepository.AddUser(user.ToModel(_unitOfWork));

            return user;
        }

        public async Task FinishMaterial(int id, UserDTO userDTO)
        {
            if (userDTO != null)
            {
                Materials material = await _unitOfWork.MaterialsRepository.GetMaterials(id);
                User user = await _unitOfWork.UserRepository.GetUser(userDTO.Id);
                user.Materials.Add(material);
                await _unitOfWork.UserRepository.UpdateUser(user);
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            var result = await _unitOfWork.UserRepository.DeleteUser(id);

            return result != null;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUser()
        {
            return (await _unitOfWork.UserRepository.GetAllUser()).Select(x => x.ToDTO());
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            await _unitOfWork.UserRepository.UpdateUser(user.ToModel(_unitOfWork));

            return user;
        }

        public async Task<bool> IsValidUser(string mail, string password)
        {
            return await _unitOfWork.UserRepository.IsValidUser(mail, password);
        }

        public async Task<UserDTO> GetUser(int id)
        {
            return UserMapping.ToDTO(await _unitOfWork.UserRepository.GetUser(id));
        }

        public async Task<UserDTO> GetUser(string mail, string password)
        {
            return UserMapping.ToDTO(await _unitOfWork.UserRepository.GetUser(mail, password));
        }

        public async Task<UserDTO> GetUser(string mail)
        {
            return UserMapping.ToDTO(await _unitOfWork.UserRepository.GetUser(mail));
        }
    }
}
