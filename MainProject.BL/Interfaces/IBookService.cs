using MainProject.BL.DTO;

namespace MainProject.BL.Interfaces
{
    public interface IBookService
    {
        public BookDTO AddBook(BookDTO bookMaterial);
        public BookDTO UpdateBook(int id, BookDTO bookMaterial);
        public List<BookDTO> GetAllBook();
        public bool DeleteBook(BookDTO bookMaterial);
    }
}
