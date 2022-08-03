using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.src.Models
{
    public class BookMaterial : Materials
    {
        public string Author { get; set; }
        public int NumberOfPages { get; set; }
        public string Format { get; set; }
        public DateTime Date { get; set; }

        public BookMaterial()
        {

        }

        public BookMaterial(int id, string author, int numberOfPages, string format, DateTime date, string name) : base(name)
        {
            Author = author ?? throw new ArgumentNullException(nameof(author));
            NumberOfPages = numberOfPages;
            Format = format ?? throw new ArgumentNullException(nameof(format));
            Date = date;
            Id = id;
        }
    }
}
