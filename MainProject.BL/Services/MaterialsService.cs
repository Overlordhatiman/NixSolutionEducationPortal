namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions.Mapping;
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
            await _unitOfWork.MaterialsRepository.Add(material.ToModel());

            return material;
        }

        public async Task<bool> DeleteMaterial(int id)
        {
            var result = await _unitOfWork.MaterialsRepository.Delete(id);

            return result != null;
        }

        public async Task<List<MaterialsDTO>> GetAllMaterial()
        {
            List<MaterialsDTO> materials = new List<MaterialsDTO>();
            foreach (var material in await _unitOfWork.MaterialsRepository.GetAll())
            {
                materials.Add(material.ToDTO());
            }

            return materials;
        }

        public async Task<MaterialsDTO> UpdateMaterial(MaterialsDTO material)
        {
            await _unitOfWork.MaterialsRepository.Update(material.ToModel());

            return material;
        }

        public async Task<MaterialsDTO> GetMaterials(int id)
        {
            return MaterialMapping.ToDTO(await _unitOfWork.MaterialsRepository.GetById(id));
        }
    }
}
