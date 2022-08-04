namespace MainProject.UI
{
    using MainProject.BL.Extentions;
    using MainProject.UI.Managed;
    using Microsoft.Extensions.DependencyInjection;

    public static class Program
    {
        static void Main(string[] args)
        {
            var temp = new ServiceCollection();
            temp.AddServices();

            var services = temp.BuildServiceProvider();

            MainMenu mainMenu = new MainMenu(services);

            if (mainMenu.IsValidUser())
            {
                mainMenu.ShowMainMenu();
            }
        }
    }
}
