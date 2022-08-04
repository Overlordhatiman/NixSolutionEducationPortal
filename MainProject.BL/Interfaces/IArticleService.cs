namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IArticleService
    {
        public ArticleDTO AddArticle(ArticleDTO articleMaterial);

        public ArticleDTO UpdateArticle(int id, ArticleDTO articleMaterial);

        public List<ArticleDTO> GetAllArticle();

        public bool DeleteArticle(int id);
    }
}
