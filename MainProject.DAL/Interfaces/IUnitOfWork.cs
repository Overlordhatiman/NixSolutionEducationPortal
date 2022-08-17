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

        public IMaterialsRepository MaterialsRepository { get; }
    }
}
