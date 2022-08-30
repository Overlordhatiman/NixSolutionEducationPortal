namespace MainProject.BL.Services
{
    using MainProject.BL.DTO;
    using MainProject.BL.Extentions.Mapping;
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

            return bookMaterial;
        }

        public bool DeleteBook(int id)
        {
            var result = _unitOfWork.BookRepository.DeleteBook(id);

            return result != null;
        }

        public List<BookDTO> GetAllBook()
        {
            List<BookDTO> books = new List<BookDTO>();
            foreach (var book in _unitOfWork.BookRepository.GetAllBook())
            {
                books.Add(book.ToDTO());
            }

            return books;
        }

        public BookDTO UpdateBook(BookDTO bookMaterial)
        {
            _unitOfWork.BookRepository.UpdateBook(bookMaterial.ToModel());

            return bookMaterial;
        }

        public BookDTO GetBookMaterial(int id)
        {
           return _unitOfWork.BookRepository.GetBookMaterial(id).ToDTO();
        }
    }
}
