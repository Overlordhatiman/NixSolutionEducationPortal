namespace MainProject.UI
{
    using MainProject.BL.Extentions;
    using MainProject.UI.Managed;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddScoped<SkillCRUD>();
            services.AddScoped<CourseCRUD>();
            services.AddScoped<UserCRUD>();
            services.AddScoped<MaterialsCRUD>();
            services.AddScoped<MainMenu>();

            services.AddServices();

            var provider = services.BuildServiceProvider();

            MainMenu mainMenu = provider.GetRequiredService<MainMenu>();
            mainMenu.ShowRegisterMenu();
        }
    }
}
