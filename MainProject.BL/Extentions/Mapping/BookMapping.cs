namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Models;

    public static class BookMapping
    {
        public static BookDTO ToDTO(this BookMaterial bookMaterial)
        {
            if (bookMaterial == null)
            {
                return new BookDTO();
            }

            return new BookDTO
            {
                Id = bookMaterial.Id,
                Name = bookMaterial.Name,
                Author = bookMaterial.Author,
                Date = bookMaterial.Date,
                Format = bookMaterial.Format,
                NumberOfPages = bookMaterial.NumberOfPages,
            };
        }

        public static BookMaterial ToModel(this BookDTO book)
        {
            if (book == null)
            {
                return new BookMaterial();
            }

            return new BookMaterial
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Date = book.Date,
                Format = book.Format,
                NumberOfPages = book.NumberOfPages,
            };
        }
    }
}
