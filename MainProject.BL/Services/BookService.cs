namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions;
    using MainProject.BL.Interfaces;
    using MainProject.DAL.Interfaces;

    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BookDTO AddBook(BookDTO bookMaterial)
        {
            _unitOfWork.BookRepository.AddBook(bookMaterial.ToModel());
            _unitOfWork.Save();

            return bookMaterial;
        }

        public bool DeleteBook(int id)
        {
            bool result = _unitOfWork.BookRepository.DeleteBook(id);
            _unitOfWork.Save();

            return result;
        }

        public List<BookDTO> GetAllBook()
        {
            List<BookDTO> books = new List<BookDTO>();
            foreach (var item in _unitOfWork.BookRepository.GetAllBook())
            {
                books.Add(item.ToDTO());
            }

            return books;
        }

        public BookDTO UpdateBook(int id, BookDTO bookMaterial)
        {
            _unitOfWork.BookRepository.UpdateBook(id, bookMaterial.ToModel());
            _unitOfWork.Save();

            return bookMaterial;
        }
    }
}
