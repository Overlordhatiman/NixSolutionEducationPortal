namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

    public class DbUnitOfWork : IUnitOfWork
    {
        private readonly EducationPortalContext _context;

        private DbArticleRepository? _articleRepository;

        private DbBookRepository? _bookRepository;

        private DbVideoRepository? _videoRepository;

        private DbCourseRepository? _courseRepository;

        private BaseRepository<Skill>? _skillRepository;

        private DbUserRepository? _userRepository;

        private BaseRepository<Materials>? _materialsRepository;

        public DbUnitOfWork(EducationPortalContext context)
        {
            _context = context;
        }

        public IArticleRepository ArticleRepository => _articleRepository ??= new DbArticleRepository(_context);

        public IBookRepository BookRepository => _bookRepository ??= new DbBookRepository(_context);

        public IVideoRepository VideoRepository => _videoRepository ??= new DbVideoRepository(_context);

        public ICourseRepository CourseRepository => _courseRepository ??= new DbCourseRepository(_context);

        public IGenericInterface<Skill> SkillRepository => _skillRepository ??= new BaseRepository<Skill>(_context);

        public IUserRepository UserRepository => _userRepository ??= new DbUserRepository(_context);

        public IGenericInterface<Materials> MaterialsRepository => _materialsRepository ??= new BaseRepository<Materials>(_context);
    }
}
