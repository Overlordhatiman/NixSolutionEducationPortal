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

            services.AddScoped<SkillController>();
            services.AddScoped<CourseController>();
            services.AddScoped<UserController>();
            services.AddScoped<MaterialsController>();
            services.AddScoped<UserCourseController>();
            services.AddScoped<MainMenu>();

            services.AddServices();

            var provider = services.BuildServiceProvider();

            try
            {
                MainMenu mainMenu = provider.GetRequiredService<MainMenu>();
                mainMenu.ShowRegisterMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
