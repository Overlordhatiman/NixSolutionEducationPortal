namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IArticleService
    {
        public Task<ArticleDTO> AddArticle(ArticleDTO articleMaterial);

        public Task<ArticleDTO> UpdateArticle(int id, ArticleDTO articleMaterial);

        public List<ArticleDTO> GetAllArticle();

        public Task<bool> DeleteArticle(int id);
    }
}
