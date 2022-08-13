namespace MainProject.DAL.Repositories.FileRepository
{
    using MainProject.DAL.Interfaces;

    public class FileUnitOfWork : IUnitOfWork
    {
        private FileArticleRepository? _articleRepository;

        private FileBookRepository? _bookRepository;

        private FileVideoRepository? _videoRepository;

        private FileCourseRepository? _courseRepository;

        private FileSkillRepository? _skillRepository;

        private FileUserRepository? _userRepository;

        private FileMaterialsRepository? _materialsRepository;

        public IMaterialsRepository MaterialsRepository => _materialsRepository ??= new FileMaterialsRepository();

        public IUserRepository UserRepository => _userRepository ??= new FileUserRepository();

        public ISkillRepository SkillRepository => _skillRepository ??= new FileSkillRepository();

        public ICourseRepository CourseRepository => _courseRepository ??= new FileCourseRepository();

        public IVideoRepository VideoRepository => _videoRepository ??= new FileVideoRepository();

        public IBookRepository BookRepository => _bookRepository ??= new FileBookRepository();

        public IArticleRepository ArticleRepository => _articleRepository ??= new FileArticleRepository();

        public void Save()
        {
            _articleRepository?.Save();
            _bookRepository?.Save();
            _videoRepository?.Save();
            _courseRepository?.Save();
            _skillRepository?.Save();
            _userRepository?.Save();
            _materialsRepository?.Save();
        }
    }
}
