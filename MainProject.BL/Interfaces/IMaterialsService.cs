namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IMaterialsService
    {
        public MaterialsDTO AddMaterial(MaterialsDTO material);

        public MaterialsDTO UpdateMaterial(int id, MaterialsDTO material);

        public List<MaterialsDTO> GetAllMaterial();

        public bool DeleteMaterial(int id);
    }
}
