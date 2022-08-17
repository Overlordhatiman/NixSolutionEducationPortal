namespace MainProject.BL.Interfaces
{
    using MainProject.BL.DTO;

    public interface IBookService
    {
        public BookDTO AddBook(BookDTO bookMaterial);

        public BookDTO UpdateBook(BookDTO bookMaterial);

        public List<BookDTO> GetAllBook();

        public bool DeleteBook(int id);

        public BookDTO GetBookMaterial(int id);
    }
}
