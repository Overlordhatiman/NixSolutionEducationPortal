namespace MainProject.BL.Extentions
{
    using MainProject.BL.Interfaces;
    using MainProject.BL.Services;
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Repositories.DbRepository;
    using MainProject.DAL.Repositories.FileRepository;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtentions
    {
        public static void AddServices(this ServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IMaterialsService, MaterialsService>();

            services.AddDbContext<EducationPortalContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbDAL();
        }

        public static void AddFileDAL(this ServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, FileUnitOfWork>();
        }

        public static void AddDbDAL(this ServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, DbUnitOfWork>();
        }
    }
}
