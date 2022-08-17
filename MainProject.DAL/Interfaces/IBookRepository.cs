namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IBookRepository
    {
        public BookMaterial AddBook(BookMaterial bookMaterial);

        public BookMaterial UpdateBook(BookMaterial bookMaterial);

        public IEnumerable<BookMaterial> GetAllBook();

        public bool DeleteBook(int id);

        public BookMaterial GetBookMaterial(int id);
    }
}
