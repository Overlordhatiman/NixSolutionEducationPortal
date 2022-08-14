namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IArticleRepository
    {
        public ArticleMaterial AddArticle(ArticleMaterial articleMaterial);

        public Task<ArticleMaterial> UpdateArticle(ArticleMaterial articleMaterial);

        public Task<IEnumerable<ArticleMaterial>> GetAllArticle();

        public Task<bool> DeleteArticle(int id);

        public Task<ArticleMaterial> GetArticleMaterial(int id);
    }
}
