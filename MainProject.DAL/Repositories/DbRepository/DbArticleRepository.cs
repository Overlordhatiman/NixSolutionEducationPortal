namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbArticleRepository : IArticleRepository
    {
        private EducationPortalContext _context;

        public DbArticleRepository(EducationPortalContext context)
        {
            _context = context;
        }

        public ArticleMaterial AddArticle(ArticleMaterial articleMaterial)
        {
            _context.Articles.Add(articleMaterial);

            return articleMaterial;
        }

        public async Task<bool> DeleteArticle(int id)
        {
           var entityToDelete = await _context.Articles.SingleOrDefaultAsync(e => e.Id == id);
           var obj = _context.Articles.Remove(entityToDelete);

           return obj != null;
        }

        public async Task<IEnumerable<ArticleMaterial>> GetAllArticle()
        {
            var articles = await _context.Articles.ToListAsync();

            return articles;
        }

        public async Task<ArticleMaterial> UpdateArticle(ArticleMaterial articleMaterial)
        {
            if (articleMaterial == null)
            {
                return null;
            }

            var article = await _context.Articles.FirstOrDefaultAsync(x => x.Id == articleMaterial.Id);

            if (article != null)
            {
                article.Resource = articleMaterial.Resource;
                article.Name = articleMaterial.Name;
                article.Date = articleMaterial.Date;
            }

            _context.Entry(article).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return article;
        }

        public Task<ArticleMaterial> GetArticleMaterial(int id)
        {
            return _context.Articles.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
