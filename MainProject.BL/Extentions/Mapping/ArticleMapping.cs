namespace MainProject.BL.Extentions.Mapping
{
    using MainProject.BL.DTO;
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

        public static ArticleMaterial ToModel(this ArticleDTO article)
        {
            if (article == null)
            {
                return new ArticleMaterial();
            }

            return new ArticleMaterial
            {
                Id = article.Id,
                Date = article.Date,
                Name = article.Name,
                Resource = article.Resource,
            };
        }
    }
}
