namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IMaterialsService
    {
        public Task<MaterialsDTO> AddMaterial(MaterialsDTO material);

        public Task<MaterialsDTO> UpdateMaterial(int id, MaterialsDTO material);

        public List<MaterialsDTO> GetAllMaterial();

        public Task<bool> DeleteMaterial(int id);
    }
}
