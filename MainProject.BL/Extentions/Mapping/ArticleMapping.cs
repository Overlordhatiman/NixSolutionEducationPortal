namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

    public static class ArticleMapping
    {
        public static ArticleDTO ToDTO(this ArticleMaterial articleMaterial)
        {
            if (articleMaterial == null)
            {
                return new ArticleDTO();
            }

            return new ArticleDTO
            {
                Id = articleMaterial.Id,
                Date = articleMaterial.Date,
                Name = articleMaterial.Name,
                Resource = articleMaterial.Resource,
            };
        }

        public static ArticleMaterial ToModel(this ArticleDTO article, IUnitOfWork unitOfWork)
        {
            if (article == null)
            {
                return new ArticleMaterial();
            }

            Materials materials;
            if (article.Id != 0 && unitOfWork != null)
            {
                materials = unitOfWork.MaterialsRepository.GetMaterials(article.Id).Result;
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
                    Date = article.Date,
                    Name = article.Name,
                    Resource = article.Resource,
                };
            }

            return (ArticleMaterial)materials;
        }
    }
}
