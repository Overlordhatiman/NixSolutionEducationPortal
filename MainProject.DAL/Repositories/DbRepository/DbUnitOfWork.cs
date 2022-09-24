namespace MainProject.DAL.Repositories.DbRepository
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Models;

    public class DbUnitOfWork : IUnitOfWork
    {
        private readonly EducationPortalContext _context;

        private DbCourseRepository? _courseRepository;

        private DbSkillRepository? _skillRepository;

        private DbUserRepository? _userRepository;

        private DbMaterialsRepository? _materialsRepository;

        private DbUserSkillRepository _userSkillRepository;

        private DbUserCourseRepository _userCourseRepository;

        public DbUnitOfWork(EducationPortalContext context)
        {
            _context = context;
        }

        public ICourseRepository CourseRepository => _courseRepository ??= new DbCourseRepository(_context);

        public ISkillRepository SkillRepository => _skillRepository ??= new DbSkillRepository(_context);

        public IUserRepository UserRepository => _userRepository ??= new DbUserRepository(_context);

        public IMaterialsRepository MaterialsRepository => _materialsRepository ??= new DbMaterialsRepository(_context);

        public IUserSkillRepository UserSkillsRepository => _userSkillRepository ??= new DbUserSkillRepository(_context);

        public IUserCourseRepository UserCoursesRepository => _userCourseRepository ??= new DbUserCourseRepository(_context);
    }
}
