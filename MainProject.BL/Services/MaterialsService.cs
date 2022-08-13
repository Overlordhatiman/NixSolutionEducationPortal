namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class MaterialsService : IMaterialsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MaterialsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MaterialsDTO> AddMaterial(MaterialsDTO material)
        {
            _unitOfWork.MaterialsRepository.AddMaterial(material.ToModel());
            await _unitOfWork.Save();

            return material;
        }

        public async Task<bool> DeleteMaterial(int id)
        {
            var result = _unitOfWork.MaterialsRepository.DeleteMaterial(id);
            await _unitOfWork.Save();

            return result;
        }

        public List<MaterialsDTO> GetAllMaterial()
        {
            List<MaterialsDTO> materials = new List<MaterialsDTO>();
            foreach (var item in _unitOfWork.MaterialsRepository.GetAllMaterial())
            {
                materials.Add(item.ToDTO());
            }

            return materials;
        }

        public async Task<MaterialsDTO> UpdateMaterial(int id, MaterialsDTO material)
        {
            _unitOfWork.MaterialsRepository.UpdateMaterial(id, material.ToModel());
            await _unitOfWork.Save();

            return material;
        }
    }
}
