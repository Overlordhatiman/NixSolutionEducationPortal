using FluentValidation.Results;
using MainProject.BL.DTO;
using MainProject.BL.Interfaces;
using MainProject.UI.Validation;

namespace MainProject.UI.Managed
{
    public class ArticleCRUD
    {
        private static IArticleService _articleService;

        private static ArticleValidation _articleValidation;

        public ArticleCRUD(IArticleService service)
        {
            _articleService = service;
            _articleValidation = new ArticleValidation();
        }

        public static ArticleDTO GetArticleFromConsole()
        {
            Console.WriteLine("Input Name");
            string name = Console.ReadLine();

            DateTime dateOfPublication;
            DateTime.TryParse(Console.ReadLine(), out dateOfPublication);

            ArticleDTO article = new ArticleDTO
            {
                Name = name,
                Date = dateOfPublication
            };

            return Validate(article);
        }

        public static ArticleDTO GetArticleById(int id)
        {
            return _articleService.GetArticleMaterial(id);
        }

        public void CreateArticle()
        {
            CreateArticle(GetArticleFromConsole());
        }

        public void UpdateArticle()
        {
            int id = GetId();
            Console.WriteLine("Current object");
            Console.WriteLine(_articleService.GetArticleMaterial(id));

            UpdateArticle(GetArticleFromConsole(), id);
        }

        public void DeleteArticle()
        {
            DeleteArticle(GetId());
        }

        public void OutputArticles()
        {
            Console.WriteLine("Skills");
            var articles = _articleService.GetAllArticle();

            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }

            Console.ReadKey();
        }

        private static ArticleDTO Validate(ArticleDTO article)
        {
            ValidationResult validationResult = _articleValidation.Validate(article);

            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            Console.ReadKey();

            if (validationResult.IsValid)
            {
                return article;
            }

            return null;
        }

        private int GetId()
        {
            Console.WriteLine("Input ID");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            return id;
        }

        private void CreateArticle(ArticleDTO article)
        {
            if (article == null)
            {
                return;
            }

            _articleService.AddArticle(article);
        }

        private void UpdateArticle(ArticleDTO article, int id)
        {
            if (article == null)
            {
                return;
            }

            article.Id = id;
            _articleService.UpdateArticle(article);
        }

        private void DeleteArticle(int id)
        {
            _articleService.DeleteArticle(id);
        }
    }
}
