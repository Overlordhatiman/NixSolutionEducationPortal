namespace MainProject.DAL.Interfaces
{
    using MainProject.src.Models;

    public interface IBookRepository
    {
        public BookMaterial AddBook(BookMaterial bookMaterial);

        public BookMaterial UpdateBook(int id, BookMaterial bookMaterial);

        public List<BookMaterial> GetAllBook();

        public bool DeleteBook(int id);
    }
}
