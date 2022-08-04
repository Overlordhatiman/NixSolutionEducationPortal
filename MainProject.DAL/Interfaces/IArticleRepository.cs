using MainProject.src.Models;
namespace MainProject.DAL.Interfaces
{
    public interface IArticleRepository
    {
        public ArticleMaterial AddArticle(ArticleMaterial articleMaterial);

        public ArticleMaterial UpdateArticle(int id, ArticleMaterial articleMaterial);

        public List<ArticleMaterial> GetAllArticle();

        public bool DeleteArticle(int id);
    }
}
