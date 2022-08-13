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

        public async Task<BookDTO> AddBook(BookDTO bookMaterial)
        {
            _unitOfWork.BookRepository.AddBook(bookMaterial.ToModel());
            await _unitOfWork.Save();

            return bookMaterial;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var result = _unitOfWork.BookRepository.DeleteBook(id);
            await _unitOfWork.Save();

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

        public async Task<BookDTO> UpdateBook(int id, BookDTO bookMaterial)
        {
            _unitOfWork.BookRepository.UpdateBook(id, bookMaterial.ToModel());
            await _unitOfWork.Save();

            return bookMaterial;
        }
    }
}
