namespace MainProject.DAL.Repositories
{
    using MainProject.DAL.Interfaces;
    using MainProject.src.Models;
    using Newtonsoft.Json;

    public class FileArticleRepository : IArticleRepository
    {
        private List<ArticleMaterial>? _articles;

        public FileArticleRepository()
        {
            string str = File.ReadAllText(DALConstant.ArticleFilePath);

            _articles = JsonConvert.DeserializeObject<List<ArticleMaterial>>(str);
        }

        public ArticleMaterial AddArticle(ArticleMaterial articleMaterial)
        {
            _articles?.Add(articleMaterial);

            return articleMaterial;
        }

        public bool DeleteArticle(int id)
        {
            return _articles.Remove(_articles.Find(x=>x.Id==id));
        }

        public List<ArticleMaterial> GetAllArticle()
        {
            return _articles;
        }

        public ArticleMaterial UpdateArticle(int id, ArticleMaterial articleMaterial)
        {
            int index = _articles.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return new ArticleMaterial();
            }

            _articles[index] = articleMaterial;

            return articleMaterial;
        }

        public void Save()
        {
            var str = JsonConvert.SerializeObject(_articles, Formatting.Indented);

            File.WriteAllText(DALConstant.ArticleFilePath, str);
        }
    }
}
