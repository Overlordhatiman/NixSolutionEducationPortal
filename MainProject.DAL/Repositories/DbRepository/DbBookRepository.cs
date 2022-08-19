namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DbBookRepository : IBookRepository
    {
        private EducationPortalContext _context;

        public DbBookRepository(EducationPortalContext context)
        {
            _context = context;
        }

        public BookMaterial AddBook(BookMaterial bookMaterial)
        {
            _context.Books.Add(bookMaterial);
            _context.SaveChanges();

            return bookMaterial;
        }

        public bool DeleteBook(int id)
        {
            var entityToDelete = _context.Books.SingleOrDefault(e => e.Id == id);
            var obj = _context.Books.Remove(entityToDelete);
            _context.SaveChanges();

            return obj != null;
        }

        public IEnumerable<BookMaterial> GetAllBook()
        {
            return _context.Books.AsNoTracking().ToList();
        }

        public BookMaterial UpdateBook(BookMaterial bookMaterial)
        {
            if (bookMaterial == null)
            {
                return null;
            }

            _context.Update(bookMaterial);
            _context.SaveChanges();

            return bookMaterial;
        }

        public BookMaterial GetBookMaterial(int id)
        {
            return _context.Books.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }
    }
}
