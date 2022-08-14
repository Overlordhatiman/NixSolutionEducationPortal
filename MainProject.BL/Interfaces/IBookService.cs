namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IBookService
    {
        public Task<BookDTO> AddBook(BookDTO bookMaterial);

        public Task<BookDTO> UpdateBook(BookDTO bookMaterial);

        public Task<List<BookDTO>> GetAllBook();

        public Task<bool> DeleteBook(int id);

        public Task<BookDTO> GetBookMaterial(int id);
    }
}
