namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IArticleService
    {
        public Task<ArticleDTO> AddArticle(ArticleDTO articleMaterial);

        public Task<ArticleDTO> UpdateArticle(ArticleDTO articleMaterial);

        public Task<List<ArticleDTO>> GetAllArticle();

        public Task<bool> DeleteArticle(int id);

        public Task<ArticleDTO> GetArticleMaterial(int id);
    }
}
