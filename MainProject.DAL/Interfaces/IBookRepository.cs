using MainProject.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.Interfaces
{
    public interface IBookRepository
    {
        public BookMaterial AddBook(BookMaterial bookMaterial);
        public BookMaterial UpdateBook(int id, BookMaterial bookMaterial);
        public List<BookMaterial> GetAllBook();
        public bool DeleteBook(BookMaterial bookMaterial);
    }
}
