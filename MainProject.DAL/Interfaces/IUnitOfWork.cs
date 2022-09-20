namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IUnitOfWork
    {
        public ICourseRepository CourseRepository { get; }

        public IGenericInterface<Skill> SkillRepository { get; }

        public IUserRepository UserRepository { get; }

        public IMaterialsRepository MaterialsRepository { get; }

        public IGenericInterface<UserSkill> UserSkillsRepository { get; }

        public IUserCourseRepository UserCoursesRepository { get; }
    }
}
