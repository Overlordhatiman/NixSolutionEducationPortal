using MainProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAL.Repositories
{
    public class FileUnitOfWork : IUnitOfWork
    {
        private FileArticleRepository articleRepository;
        public IArticleRepository ArticleRepository => articleRepository ??= new FileArticleRepository();

        private FileBookRepository bookRepository;

        public IBookRepository BookRepository => bookRepository ??= new FileBookRepository();

        private FileVideoRepository videoRepository;

        public IVideoRepository VideoRepository => videoRepository ??= new FileVideoRepository();

        private FileCourseRepository courseRepository;

        public ICourseRepository CourseRepository => courseRepository ??= new FileCourseRepository();

        private FileSkillRepository skillRepository;

        public ISkillRepository SkillRepository => skillRepository ??= new FileSkillRepository();

        private FileUserRepository userRepository;

        public IUserRepository UserRepository => userRepository ??= new FileUserRepository();

        public void Save()
        {
            articleRepository?.Save();
            bookRepository?.Save();
            videoRepository?.Save();
            courseRepository?.Save();
            skillRepository?.Save();
            userRepository?.Save();
        }
    }
}
