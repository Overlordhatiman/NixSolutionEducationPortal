using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IArticleRepository ArticleRepository { get; }
        public IBookRepository BookRepository { get; }
        public IVideoRepository VideoRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IUserRepository UserRepository { get; }

        public void Save();
    }
}
