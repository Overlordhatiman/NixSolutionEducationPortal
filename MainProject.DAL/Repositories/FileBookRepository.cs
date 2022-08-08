namespace MainProject.DAL.Repositories
{
    using MainProject.DAL.Interfaces;
    using MainProject.src.Models;
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
            return _books.Remove(_books.Find(x=>x.Id==id));
        }

        public List<BookMaterial> GetAllBook()
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

        public void Save()
        {
            var str = JsonConvert.SerializeObject(_books, Formatting.Indented);

            File.WriteAllText(DALConstant.BookFilePath, str);
        }
    }
}
