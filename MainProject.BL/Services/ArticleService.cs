using MainProject.BL.DTO;
using MainProject.BL.Interfaces;
using MainProject.DAL.Interfaces;
using MainProject.BL.Extentions;

namespace MainProject.BL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public ArticleDTO AddArticle(ArticleDTO articleMaterial)
        {
            _unitOfWork.ArticleRepository.AddArticle((articleMaterial).ToModel());
            _unitOfWork.Save();

            return articleMaterial;
        }

        public bool DeleteArticle(ArticleDTO articleMaterial)
        {
            bool result = _unitOfWork.ArticleRepository.DeleteArticle((articleMaterial).ToModel());
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
            _unitOfWork.ArticleRepository.UpdateArticle(id, (articleMaterial).ToModel());
            _unitOfWork.Save();

            return articleMaterial;
        }
    }
}
