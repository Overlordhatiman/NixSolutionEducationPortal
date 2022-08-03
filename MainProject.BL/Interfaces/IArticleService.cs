using MainProject.BL.DTO;

namespace MainProject.BL.Interfaces
{
    public interface IArticleService
    {
        public ArticleDTO AddArticle(ArticleDTO articleMaterial);
        public ArticleDTO UpdateArticle(int id, ArticleDTO articleMaterial);
        public List<ArticleDTO> GetAllArticle();
        public bool DeleteArticle(ArticleDTO articleMaterial);
    }
}
