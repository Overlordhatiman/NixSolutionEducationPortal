namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

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

            return bookMaterial;
        }

        public bool DeleteBook(int id)
        {
            var obj = _context.Books.Remove(_context.Books.SingleOrDefault(e => e.Id == id));

            return obj != null;
        }

        public IEnumerable<BookMaterial> GetAllBook()
        {
            return _context.Books;
        }

        public BookMaterial UpdateBook(int id, BookMaterial bookMaterial)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            book = bookMaterial;

            return bookMaterial;
        }
    }
}
