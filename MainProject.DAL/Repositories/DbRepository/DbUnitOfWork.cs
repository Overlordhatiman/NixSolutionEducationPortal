namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

    public class DbUnitOfWork : IUnitOfWork
    {
        private readonly EducationPortalContext _context;

        private DbCourseRepository? _courseRepository;

        private BaseRepository<Skill>? _skillRepository;

        private DbUserRepository? _userRepository;

        private DbMaterialsRepository? _materialsRepository;

        private BaseRepository<UserSkill> _userSkillRepository;

        private DbUserCourseRepository _userCourseRepository;

        public DbUnitOfWork(EducationPortalContext context)
        {
            _context = context;
        }

        public ICourseRepository CourseRepository => _courseRepository ??= new DbCourseRepository(_context);

        public IGenericInterface<Skill> SkillRepository => _skillRepository ??= new BaseRepository<Skill>(_context);

        public IUserRepository UserRepository => _userRepository ??= new DbUserRepository(_context);

        public IMaterialsRepository MaterialsRepository => _materialsRepository ??= new DbMaterialsRepository(_context);

        public IGenericInterface<UserSkill> UserSkillsRepository => _userSkillRepository ??= new BaseRepository<UserSkill>(_context);

        public IUserCourseRepository UserCoursesRepository => _userCourseRepository ??= new DbUserCourseRepository(_context);
    }
}
