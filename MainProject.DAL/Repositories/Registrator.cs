namespace MainProject.DAL.Repositories
{
    using MainProject.DAL.Interfaces;
    using MainProject.DAL.Repositories.DbRepository;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class Registrator
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EducationPortalContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, DbUnitOfWork>();
        }
    }
}
