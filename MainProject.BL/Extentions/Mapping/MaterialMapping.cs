namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Interfaces;
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

        public static Materials ToModel(this MaterialsDTO material, IUnitOfWork unitOfWork)
        {
            if (material == null)
            {
                return new Materials();
            }

            Materials materials;
            bool exist = false;

            if (material.Id != 0 && unitOfWork != null)
            {
                materials = unitOfWork.MaterialsRepository.GetMaterials(material.Id).Result;
                materials.Id = material.Id;
                materials.Name = material.Name;
                exist = true;
            }
            else
            {
                materials = new Materials
                {
                    Id = material.Id,
                    Name = material.Name,
                };
            }

            if (material is ArticleDTO article)
            {
                if (exist)
                {
                    ArticleMaterial articleMaterial = (ArticleMaterial)materials;
                    articleMaterial.Id = article.Id;
                    articleMaterial.Name = article.Name;
                    articleMaterial.Date = article.Date;
                    articleMaterial.Resource = article.Resource;
                    materials = articleMaterial;
                }
                else
                {
                    materials = new ArticleMaterial
                    {
                        Id = article.Id,
                        Name = article.Name,
                        Date = article.Date,
                        Resource = article.Resource,
                    };
                }
            }

            if (material is BookDTO book)
            {
                if (exist)
                {
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
                        Author = book.Author,
                        Date = book.Date,
                        Format = book.Format,
                        NumberOfPages = book.NumberOfPages,
                        Name = book.Name,
                    };
                }
            }

            if (material is VideoDTO video)
            {
                if (exist)
                {
                    VideoMaterial videoMaterial = (VideoMaterial)materials;
                    videoMaterial.Id = video.Id;
                    videoMaterial.Name = video.Name;
                    videoMaterial.Quality = video.Quality;
                    videoMaterial.Time = video.Time;
                    materials = videoMaterial;
                }
                else
                {
                    materials = new VideoMaterial
                    {
                        Id = video.Id,
                        Name = video.Name,
                        Quality = video.Quality,
                        Time = video.Time,
                    };
                }
            }

            return materials;
        }
    }
}
