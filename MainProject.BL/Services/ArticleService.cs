namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ArticleDTO AddArticle(ArticleDTO articleMaterial)
        {
            _unitOfWork.ArticleRepository.AddArticle(articleMaterial.ToModel());

            return articleMaterial;
        }

        public bool DeleteArticle(int id)
        {
            var result = _unitOfWork.ArticleRepository.DeleteArticle(id);

            return result != null;
        }

        public List<ArticleDTO> GetAllArticle()
        {
            List<ArticleDTO> articles = new List<ArticleDTO>();

            foreach (var article in _unitOfWork.ArticleRepository.GetAllArticle())
            {
                articles.Add(article.ToDTO());
            }

            return articles;
        }

        public ArticleDTO UpdateArticle(ArticleDTO articleMaterial)
        {
            _unitOfWork.ArticleRepository.UpdateArticle(articleMaterial.ToModel());

            return articleMaterial;
        }

        public ArticleDTO GetArticleMaterial(int id)
        {
            return _unitOfWork.ArticleRepository.GetArticleMaterial(id).ToDTO();
        }
    }
}
