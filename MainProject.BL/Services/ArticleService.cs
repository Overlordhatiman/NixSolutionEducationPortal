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

        public async Task<ArticleDTO> AddArticle(ArticleDTO articleMaterial)
        {
            _unitOfWork.ArticleRepository.AddArticle(articleMaterial.ToModel());
            await _unitOfWork.Save();

            return articleMaterial;
        }

        public async Task<bool> DeleteArticle(int id)
        {
            var result = _unitOfWork.ArticleRepository.DeleteArticle(id);
            await _unitOfWork.Save();

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

        public async Task<ArticleDTO> UpdateArticle(int id, ArticleDTO articleMaterial)
        {
            _unitOfWork.ArticleRepository.UpdateArticle(id, articleMaterial.ToModel());
            await _unitOfWork.Save();

            return articleMaterial;
        }
    }
}
