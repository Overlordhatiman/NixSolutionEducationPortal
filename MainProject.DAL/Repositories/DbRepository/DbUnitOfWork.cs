namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;

    public class DbUnitOfWork : IUnitOfWork
    {
        private readonly EducationPortalContext _context;

        private DbArticleRepository? _articleRepository;

        private DbBookRepository? _bookRepository;

        private DbVideoRepository? _videoRepository;

        private DbCourseRepository? _courseRepository;

        private DbSkillRepository? _skillRepository;

        private DbUserRepository? _userRepository;

        private DbMaterialsRepository? _materialsRepository;

        public DbUnitOfWork(EducationPortalContext context)
        {
            _context = context;
        }

        public IArticleRepository ArticleRepository => _articleRepository ??= new DbArticleRepository(_context);

        public IBookRepository BookRepository => _bookRepository ??= new DbBookRepository(_context);

        public IVideoRepository VideoRepository => _videoRepository ??= new DbVideoRepository(_context);

        public ICourseRepository CourseRepository => _courseRepository ??= new DbCourseRepository(_context);

        public ISkillRepository SkillRepository => _skillRepository ??= new DbSkillRepository(_context);

        public IUserRepository UserRepository => _userRepository ??= new DbUserRepository(_context);

        public IMaterialsRepository MaterialsRepository => _materialsRepository ??= new DbMaterialsRepository(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
