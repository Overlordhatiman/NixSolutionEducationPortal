namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IMaterialsService
    {
        public Task<MaterialsDTO> AddMaterial(MaterialsDTO material);

        public Task<MaterialsDTO> UpdateMaterial(MaterialsDTO material);

        public Task<List<MaterialsDTO>> GetAllMaterial();

        public Task<bool> DeleteMaterial(int id);

        public Task<MaterialsDTO> GetMaterials(int id);
    }
}
