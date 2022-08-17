namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IArticleRepository
    {
        public ArticleMaterial AddArticle(ArticleMaterial articleMaterial);

        public ArticleMaterial UpdateArticle(ArticleMaterial articleMaterial);

        public IEnumerable<ArticleMaterial> GetAllArticle();

        public bool DeleteArticle(int id);

        public ArticleMaterial GetArticleMaterial(int id);
    }
}
