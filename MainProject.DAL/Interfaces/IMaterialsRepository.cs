namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IMaterialsRepository
    {
        public Task<Materials> AddMaterial(Materials material);

        public Task<Materials> UpdateMaterial(Materials material);

        public Task<IEnumerable<Materials>> GetAllMaterial();

        public Task<IEnumerable<ArticleMaterial>> GetAllArticle();

        public Task<IEnumerable<BookMaterial>> GetAllBook();

        public Task<IEnumerable<VideoMaterial>> GetAllVideo();

        public Task<bool> DeleteMaterial(int id);

        public Task<Materials> GetMaterials(int id);
    }
}
