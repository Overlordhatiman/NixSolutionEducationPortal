﻿namespace MainProject.DAL.Interfaces
{
    using MainProject.DAL.Models;

    public interface IUnitOfWork
    {
        public IArticleRepository ArticleRepository { get; }

        public IBookRepository BookRepository { get; }

        public IVideoRepository VideoRepository { get; }

        public ICourseRepository CourseRepository { get; }

        public IGenericInterface<Skill> SkillRepository { get; }

        public IUserRepository UserRepository { get; }

        public IGenericInterface<Materials> MaterialsRepository { get; }

        public IGenericInterface<UserSkill> UserSkillsRepository { get; }

        public IGenericInterface<UserCourse> UserCoursesRepository { get; }
    }
}
