namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Interfaces;
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

        public static BookMaterial ToModel(this BookDTO book, IUnitOfWork unitOfWork)
        {
            if (book == null)
            {
                return new BookMaterial();
            }

            Materials materials;
            if (book.Id != 0 && unitOfWork != null)
            {
                materials = unitOfWork.MaterialsRepository.GetMaterials(book.Id).Result;
                BookMaterial bookMaterial = (BookMaterial)materials;
                bookMaterial.Id = book.Id;
                bookMaterial.Name = book.Name;
                bookMaterial.Date = book.Date;
                bookMaterial.Author = book.Author;
                bookMaterial.Format = book.Format;
                bookMaterial.NumberOfPages = book.NumberOfPages;
                materials = bookMaterial;
            }
            else
            {
                materials = new BookMaterial
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Date = book.Date,
                    Format = book.Format,
                    NumberOfPages = book.NumberOfPages,
                };
            }

            return (BookMaterial)materials;
        }
    }
}
