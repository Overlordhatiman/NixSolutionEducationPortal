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
            _unitOfWork.Save();

            return material;
        }

        public bool DeleteMaterial(int id)
        {
            return _unitOfWork.MaterialsRepository.DeleteMaterial(id);
            _unitOfWork.Save();
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

        public MaterialsDTO UpdateMaterial(int id, MaterialsDTO material)
        {
            _unitOfWork.MaterialsRepository.UpdateMaterial(id, material.ToModel());
            _unitOfWork.Save();

            return material;
        }
    }
}
