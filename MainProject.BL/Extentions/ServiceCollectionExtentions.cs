namespace MainProject.BL.Extentions
{
    using MainProject.BL.Interfaces;
    using MainProject.BL.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtentions
    {
        public static void AddServices(this ServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IMaterialsService, MaterialsService>();
            services.AddScoped<IUserCourse, UserCourseService>();
            services.AddScoped<IUserSkill, UserSkillService>();

            MainProject.DAL.Repositories.Registrator.Register(services);
        }
    }
}
