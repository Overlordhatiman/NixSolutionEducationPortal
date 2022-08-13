namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IBookRepository
    {
        public BookMaterial AddBook(BookMaterial bookMaterial);

        public BookMaterial UpdateBook(int id, BookMaterial bookMaterial);

        public IEnumerable<BookMaterial> GetAllBook();

        public bool DeleteBook(int id);
    }
}
