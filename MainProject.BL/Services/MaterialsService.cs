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

        public MaterialsDTO AddMaterial(MaterialsDTO material)
        {
            _unitOfWork.MaterialsRepository.AddMaterial(material.ToModel());

            return material;
        }

        public bool DeleteMaterial(int id)
        {
            var result = _unitOfWork.MaterialsRepository.DeleteMaterial(id);

            return result != null;
        }

        public List<MaterialsDTO> GetAllMaterial()
        {
            List<MaterialsDTO> materials = new List<MaterialsDTO>();
            foreach (var material in _unitOfWork.MaterialsRepository.GetAllMaterial())
            {
                materials.Add(material.ToDTO());
            }

            return materials;
        }

        public MaterialsDTO UpdateMaterial(MaterialsDTO material)
        {
            _unitOfWork.MaterialsRepository.UpdateMaterial(material.ToModel());

            return material;
        }

        public MaterialsDTO GetMaterials(int id)
        {
            var materials = _unitOfWork.MaterialsRepository.GetMaterials(id);

            return materials.ToDTO();
        }
    }
}
