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

            return material;
        }

        public async Task<bool> DeleteMaterial(int id)
        {
            var result = await _unitOfWork.MaterialsRepository.DeleteMaterial(id);

            return result != null;
        }

        public async Task<List<MaterialsDTO>> GetAllMaterial()
        {
            List<MaterialsDTO> materials = new List<MaterialsDTO>();
            foreach (var material in await _unitOfWork.MaterialsRepository.GetAllMaterial())
            {
                materials.Add(material.ToDTO());
            }

            return materials;
        }

        public async Task<MaterialsDTO> UpdateMaterial(MaterialsDTO material)
        {
            await _unitOfWork.MaterialsRepository.UpdateMaterial(material.ToModel());

            return material;
        }

        public async Task<MaterialsDTO> GetMaterials(int id)
        {
            var materials = await _unitOfWork.MaterialsRepository.GetMaterials(id);

            return materials.ToDTO();
        }
    }
}
