namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IMaterialsService
    {
        public Task<MaterialsDTO> AddMaterial(MaterialsDTO material);

        public Task<MaterialsDTO> UpdateMaterial(MaterialsDTO material);

        public Task<IEnumerable<MaterialsDTO>> GetAllMaterial();

        public Task<IEnumerable<ArticleDTO>> GetAllArticle();

        public Task<IEnumerable<BookDTO>> GetAllBook();

        public Task<IEnumerable<VideoDTO>> GetAllVideo();

        public Task<bool> DeleteMaterial(int id);

        public Task<MaterialsDTO> GetMaterials(int id);
    }
}
