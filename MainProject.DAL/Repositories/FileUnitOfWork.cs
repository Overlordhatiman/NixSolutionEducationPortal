namespace MainProject.DAL.Repositories
{
    using MainProject.DAL.Interfaces;

    public class FileUnitOfWork : IUnitOfWork
    {
        private FileArticleRepository? articleRepository;

        public IArticleRepository ArticleRepository => articleRepository ??= new FileArticleRepository();

        private FileBookRepository? bookRepository;

        public IBookRepository BookRepository => bookRepository ??= new FileBookRepository();

        private FileVideoRepository? videoRepository;

        public IVideoRepository VideoRepository => videoRepository ??= new FileVideoRepository();

        private FileCourseRepository? courseRepository;

        public ICourseRepository CourseRepository => courseRepository ??= new FileCourseRepository();

        private FileSkillRepository? skillRepository;

        public ISkillRepository SkillRepository => skillRepository ??= new FileSkillRepository();

        private FileUserRepository? userRepository;

        public IUserRepository UserRepository => userRepository ??= new FileUserRepository();


        private FileMaterialsRepository? materialsRepository;

        public IMaterialsRepository MaterialsRepository => materialsRepository ??= new FileMaterialsRepository();

        public void Save()
        {
            articleRepository?.Save();
            bookRepository?.Save();
            videoRepository?.Save();
            courseRepository?.Save();
            skillRepository?.Save();
            userRepository?.Save();
            materialsRepository?.Save();
        }
    }
}
