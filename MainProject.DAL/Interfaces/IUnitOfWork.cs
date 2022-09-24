namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IUnitOfWork
    {
        public ICourseRepository CourseRepository { get; }

        public ISkillRepository SkillRepository { get; }

        public IUserRepository UserRepository { get; }

        public IMaterialsRepository MaterialsRepository { get; }

        public IUserSkillRepository UserSkillsRepository { get; }

        public IUserCourseRepository UserCoursesRepository { get; }
    }
}
