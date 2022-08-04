namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ArticleDTO AddArticle(ArticleDTO articleMaterial)
        {
            this.unitOfWork.ArticleRepository.AddArticle(articleMaterial.ToModel());
            this.unitOfWork.Save();

            return articleMaterial;
        }

        public bool DeleteArticle(int id)
        {
            bool result = this.unitOfWork.ArticleRepository.DeleteArticle(id);
            this.unitOfWork.Save();

            return result;
        }

        public List<ArticleDTO> GetAllArticle()
        {
            List<ArticleDTO> articles = new List<ArticleDTO>();
            foreach (var item in this.unitOfWork.ArticleRepository.GetAllArticle())
            {
                articles.Add(item.ToDTO());
            }

            return articles;
        }

        public ArticleDTO UpdateArticle(int id, ArticleDTO articleMaterial)
        {
            this.unitOfWork.ArticleRepository.UpdateArticle(id, articleMaterial.ToModel());
            this.unitOfWork.Save();

            return articleMaterial;
        }
    }
}
