namespace MainProject.DAL.Repositories.FileRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;
    using Newtonsoft.Json;

    public class FileBookRepository : IBookRepository
    {
        private List<BookMaterial>? _books;

        public FileBookRepository()
        {
            string str = File.ReadAllText(DALConstant.BookFilePath);

            _books = JsonConvert.DeserializeObject<List<BookMaterial>>(str);
        }

        public BookMaterial AddBook(BookMaterial bookMaterial)
        {
            _books?.Add(bookMaterial);

            return bookMaterial;
        }

        public bool DeleteBook(int id)
        {
            return _books.Remove(_books.Find(x => x.Id == id));
        }

        public IEnumerable<BookMaterial> GetAllBook()
        {
            return _books;
        }

        public BookMaterial UpdateBook(int id, BookMaterial bookMaterial)
        {
            int index = _books.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return new BookMaterial();
            }

            _books[index] = bookMaterial;

            return bookMaterial;
        }

        public async Task Save()
        {
            var str = JsonConvert.SerializeObject(_books, Formatting.Indented);

            await File.WriteAllTextAsync(DALConstant.BookFilePath, str);
        }
    }
}
