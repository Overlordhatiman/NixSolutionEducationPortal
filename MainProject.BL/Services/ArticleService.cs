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
            _unitOfWork.Save();

            return articleMaterial;
        }

        public bool DeleteArticle(int id)
        {
            bool result = _unitOfWork.ArticleRepository.DeleteArticle(id);
            _unitOfWork.Save();

            return result;
        }

        public List<ArticleDTO> GetAllArticle()
        {
            List<ArticleDTO> articles = new List<ArticleDTO>();

            foreach (var item in _unitOfWork.ArticleRepository.GetAllArticle())
            {
                articles.Add(item.ToDTO());
            }

            return articles;
        }

        public ArticleDTO UpdateArticle(int id, ArticleDTO articleMaterial)
        {
            _unitOfWork.ArticleRepository.UpdateArticle(id, articleMaterial.ToModel());
            _unitOfWork.Save();

            return articleMaterial;
        }
    }
}
