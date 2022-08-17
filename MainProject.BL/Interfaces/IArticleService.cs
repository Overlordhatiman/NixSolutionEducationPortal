namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IArticleService
    {
        public ArticleDTO AddArticle(ArticleDTO articleMaterial);

        public ArticleDTO UpdateArticle(ArticleDTO articleMaterial);

        public List<ArticleDTO> GetAllArticle();

        public bool DeleteArticle(int id);

        public ArticleDTO GetArticleMaterial(int id);
    }
}
