namespace MainProject.BL.Extentions
{
    using MainProject.BL.Interfaces;
    using MainProject.BL.Services;
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Repositories.DbRepository;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtentions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IMaterialsService, MaterialsService>();
            services.AddScoped<IUserCourse, UserCourseService>();
            services.AddScoped<IUserSkill, UserSkillService>();

            //services.AddDbContext<EducationPortalContext>();
            services.AddScoped<IUnitOfWork, DbUnitOfWork>();
        }
    }
}
