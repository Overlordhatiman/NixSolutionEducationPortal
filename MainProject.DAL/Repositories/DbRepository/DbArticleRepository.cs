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
            _context.SaveChanges();

            return articleMaterial;
        }

        public bool DeleteArticle(int id)
        {
           var entityToDelete = _context.Articles.SingleOrDefault(e => e.Id == id);
           var obj = _context.Articles.Remove(entityToDelete);
           _context.SaveChanges();

           return obj != null;
        }

        public IEnumerable<ArticleMaterial> GetAllArticle()
        {
           return _context.Articles.AsNoTracking().ToList();
        }

        public ArticleMaterial UpdateArticle(ArticleMaterial articleMaterial)
        {
            if (articleMaterial == null)
            {
                throw new NullReferenceException();
            }

            _context.Update(articleMaterial);
            _context.SaveChanges();

            return articleMaterial;
        }

        public ArticleMaterial GetArticleMaterial(int id)
        {
            return _context.Articles.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }
    }
}
