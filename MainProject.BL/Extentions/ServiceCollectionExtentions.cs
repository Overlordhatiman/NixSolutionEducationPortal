using MainProject.BL.Interfaces;
using MainProject.BL.Services;
using MainProject.DAL.Interfaces;
using MainProject.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MainProject.BL.Extentions
{
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

            services.AddFileDAL();
        }

        public static void AddFileDAL(this ServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, FileUnitOfWork>();
        }
    }
}
