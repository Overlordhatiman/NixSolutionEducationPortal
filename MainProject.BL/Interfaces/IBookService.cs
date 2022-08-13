namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IBookService
    {
        public Task<BookDTO> AddBook(BookDTO bookMaterial);

        public Task<BookDTO> UpdateBook(int id, BookDTO bookMaterial);

        public List<BookDTO> GetAllBook();

        public Task<bool> DeleteBook(int id);
    }
}
