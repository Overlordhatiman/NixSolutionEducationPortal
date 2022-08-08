namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;


    public class MaterialsService : IMaterialsService
    {
        private readonly IUnitOfWork unitOfWork;

        public MaterialsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public MaterialsDTO AddMaterial(MaterialsDTO material)
        {
            this.unitOfWork.MaterialsRepository.AddMaterial(material.ToModel());
            this.unitOfWork.Save();

            return material;
        }

        public bool DeleteMaterial(int id)
        {
            return this.unitOfWork.MaterialsRepository.DeleteMaterial(id);
            this.unitOfWork.Save();
        }

        public List<MaterialsDTO> GetAllMaterial()
        {
            List<MaterialsDTO> materials = new List<MaterialsDTO>();
            foreach (var item in this.unitOfWork.MaterialsRepository.GetAllMaterial())
            {
                materials.Add(item.ToDTO());
            }

            return materials;
        }

        public MaterialsDTO UpdateMaterial(int id, MaterialsDTO material)
        {
            this.unitOfWork.MaterialsRepository.UpdateMaterial(id, material.ToModel());
            this.unitOfWork.Save();

            return material;
        }
    }
}
