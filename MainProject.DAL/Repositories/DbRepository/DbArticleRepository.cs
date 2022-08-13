namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

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

        public bool DeleteArticle(int id)
        {
            var obj = _context.Articles.Remove(_context.Articles.SingleOrDefault(e => e.Id == id));

            return obj != null;
        }

        public IEnumerable<ArticleMaterial> GetAllArticle()
        {
            return _context.Articles;
        }

        public ArticleMaterial UpdateArticle(int id, ArticleMaterial articleMaterial)
        {
            var article = _context.Articles.SingleOrDefault(x => x.Id == id);

            article = articleMaterial;

            return articleMaterial;
        }
    }
}
