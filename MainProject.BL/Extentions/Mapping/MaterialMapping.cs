namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Models;

    public static class MaterialMapping
    {
        public static MaterialsDTO ToDTO(this Materials material)
        {
            if (material == null)
            {
                return new MaterialsDTO();
            }

            MaterialsDTO materials = new MaterialsDTO
            {
                Id = material.Id,
                Name = material.Name,
            };

            if (material is ArticleMaterial article)
            {
                materials = new ArticleDTO
                {
                    Id = article.Id,
                    Name = article.Name,
                    Date = article.Date,
                    Resource = article.Resource,
                };
            }

            if (material is BookMaterial book)
            {
                materials = new BookDTO
                {
                    Id = book.Id,
                    Author = book.Author,
                    Date = book.Date,
                    Format = book.Format,
                    NumberOfPages = book.NumberOfPages,
                    Name = book.Name,
                };
            }

            if (material is VideoMaterial video)
            {
                materials = new VideoDTO
                {
                    Id = video.Id,
                    Name = video.Name,
                    Quality = video.Quality,
                    Time = video.Time,
                };
            }

            return materials;
        }

        public static Materials ToModel(this MaterialsDTO material)
        {
            if (material == null)
            {
                return new Materials();
            }

            Materials materials = new Materials
            {
                Id = material.Id,
                Name = material.Name,
            };

            if (material is ArticleDTO article)
            {
                materials = new ArticleMaterial
                {
                    Id = article.Id,
                    Name = article.Name,
                    Date = article.Date,
                    Resource = article.Resource,
                };
            }

            if (material is BookDTO book)
            {
                materials = new BookMaterial
                {
                    Id = book.Id,
                    Author = book.Author,
                    Date = book.Date,
                    Format = book.Format,
                    NumberOfPages = book.NumberOfPages,
                    Name = book.Name,
                };
            }

            if (material is VideoDTO video)
            {
                materials = new VideoMaterial
                {
                    Id = video.Id,
                    Name = video.Name,
                    Quality = video.Quality,
                    Time = video.Time,
                };
            }

            return materials;
        }
    }
}
