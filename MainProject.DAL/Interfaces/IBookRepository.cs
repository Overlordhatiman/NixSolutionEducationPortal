namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IBookRepository
    {
        public BookMaterial AddBook(BookMaterial bookMaterial);

        public Task<BookMaterial> UpdateBook(BookMaterial bookMaterial);

        public Task<IEnumerable<BookMaterial>> GetAllBook();

        public Task<bool> DeleteBook(int id);

        public Task<BookMaterial> GetBookMaterial(int id);
    }
}
