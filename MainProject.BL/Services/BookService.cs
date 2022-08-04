namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public BookDTO AddBook(BookDTO bookMaterial)
        {
            this.unitOfWork.BookRepository.AddBook(bookMaterial.ToModel());
            this.unitOfWork.Save();

            return bookMaterial;
        }

        public bool DeleteBook(int id)
        {
            bool result = this.unitOfWork.BookRepository.DeleteBook(id);
            this.unitOfWork.Save();

            return result;
        }

        public List<BookDTO> GetAllBook()
        {
            List<BookDTO> books = new List<BookDTO>();
            foreach (var item in this.unitOfWork.BookRepository.GetAllBook())
            {
                books.Add(item.ToDTO());
            }

            return books;
        }

        public BookDTO UpdateBook(int id, BookDTO bookMaterial)
        {
            this.unitOfWork.BookRepository.UpdateBook(id, bookMaterial.ToModel());
            this.unitOfWork.Save();

            return bookMaterial;
        }
    }
}
