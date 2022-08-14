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

            return bookMaterial;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var entityToDelete = await _context.Books.SingleOrDefaultAsync(e => e.Id == id);
            var obj = _context.Books.Remove(entityToDelete);

            return obj != null;
        }

        public async Task<IEnumerable<BookMaterial>> GetAllBook()
        {
            var books = await _context.Books.ToListAsync();

            return books;
        }

        public async Task<BookMaterial> UpdateBook(BookMaterial bookMaterial)
        {
            if (bookMaterial == null)
            {
                return null;
            }

            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == bookMaterial.Id);

            if (book != null)
            {
                book.Author = bookMaterial.Author;
                book.Date = bookMaterial.Date;
                book.Format = bookMaterial.Format;
                book.NumberOfPages = bookMaterial.NumberOfPages;
            }

            _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return book;
        }

        public Task<BookMaterial> GetBookMaterial(int id)
        {
            return _context.Books.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
