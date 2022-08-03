using MainProject.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.Interfaces
{
    public interface IArticleRepository
    {
        public ArticleMaterial AddArticle(ArticleMaterial articleMaterial);
        public ArticleMaterial UpdateArticle(int id, ArticleMaterial articleMaterial);
        public List<ArticleMaterial> GetAllArticle();
        public bool DeleteArticle(ArticleMaterial articleMaterial);
    }
}
