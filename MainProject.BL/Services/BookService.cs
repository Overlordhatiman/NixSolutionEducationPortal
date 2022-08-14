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
            var result = await _unitOfWork.BookRepository.DeleteBook(id);
            await _unitOfWork.Save();

            return result != null;
        }

        public async Task<List<BookDTO>> GetAllBook()
        {
            List<BookDTO> books = new List<BookDTO>();
            foreach (var book in await _unitOfWork.BookRepository.GetAllBook())
            {
                books.Add(book.ToDTO());
            }

            return books;
        }

        public async Task<BookDTO> UpdateBook(BookDTO bookMaterial)
        {
            await _unitOfWork.BookRepository.UpdateBook(bookMaterial.ToModel());
            await _unitOfWork.Save();

            return bookMaterial;
        }

        public async Task<BookDTO> GetBookMaterial(int id)
        {
            var book = await _unitOfWork.BookRepository.GetBookMaterial(id);

            return book.ToDTO();
        }
    }
}
