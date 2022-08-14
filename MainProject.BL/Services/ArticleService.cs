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
            var result = await _unitOfWork.ArticleRepository.DeleteArticle(id);
            await _unitOfWork.Save();

            return result != null;
        }

        public async Task<List<ArticleDTO>> GetAllArticle()
        {
            List<ArticleDTO> articles = new List<ArticleDTO>();

            foreach (var article in await _unitOfWork.ArticleRepository.GetAllArticle())
            {
                articles.Add(article.ToDTO());
            }

            return articles;
        }

        public async Task<ArticleDTO> UpdateArticle(ArticleDTO articleMaterial)
        {
            await _unitOfWork.ArticleRepository.UpdateArticle(articleMaterial.ToModel());
            await _unitOfWork.Save();

            return articleMaterial;
        }

        public async Task<ArticleDTO> GetArticleMaterial(int id)
        {
            var article = await _unitOfWork.ArticleRepository.GetArticleMaterial(id);

            return article.ToDTO();
        }
    }
}
