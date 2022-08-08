namespace MainProject.UI.Managed
{
    using Microsoft.Extensions.DependencyInjection;

    public class MainMenu
    {
        private List<MenuItem> _mainMenu;

        private List<MenuItem> _courseMenu;

        private List<MenuItem> _materialsMenu;

        private MaterialsCRUD _materialsCRUD;

        private CourseCRUD _courseCRUD;

        private SkillCRUD _skillCRUD;

        private UserCRUD _userCRUD;

        public MainMenu(MaterialsCRUD materialsCRUD, CourseCRUD courseCRUD, SkillCRUD skillCRUD, UserCRUD userCRUD)
        {
            _materialsCRUD = materialsCRUD;
            _courseCRUD = courseCRUD;
            _skillCRUD = skillCRUD;
            _userCRUD = userCRUD;

            _mainMenu = new List<MenuItem>
            {
                new MenuItem {Description = "Course", Execute = ShowCourseMenu},
                new MenuItem {Description = "Materials", Execute = ShowMaterialsMenu},
            };

            _materialsMenu = new List<MenuItem>
            {
                new MenuItem {Description = "Create", Execute = _materialsCRUD.CreateMaterial},
                new MenuItem {Description = "Delete", Execute = _materialsCRUD.DeleteMaterial},
                new MenuItem {Description = "Update", Execute = _materialsCRUD.UpdateMaterial},
                new MenuItem {Description = "Output", Execute = _materialsCRUD.OutputMaterials},
            };

            _courseMenu = new List<MenuItem>
            {
                new MenuItem {Description = "Create", Execute = _courseCRUD.CreateCourse},
                new MenuItem {Description = "Delete", Execute = _courseCRUD.DeleteCourse},
                new MenuItem {Description = "Update", Execute = _courseCRUD.UpdateCourse},
                new MenuItem {Description = "Output", Execute = _courseCRUD.OutputCourse},
            };
        }

        public bool IsValidUser()
        {
            return _userCRUD.IsValid();
        }

        public void ShowMainMenu()
        {
            Menu(_mainMenu);
        }

        public void ShowCourseMenu()
        {
            Menu(_courseMenu);
        }

        public void ShowMaterialsMenu()
        {
            Menu(_materialsMenu);
        }

        private void Menu(List<MenuItem> menuItems)
        {
            ClearAndShowHeading("Material Menu");

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {menuItems[i].Description}");
            }

            int cursorTop = Console.CursorTop + 1;
            int userInput;

            do
            {
                Console.SetCursorPosition(0, cursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, cursorTop);

                Console.Write($"Enter a choice (1 - {menuItems.Count}): ");
            } while (!int.TryParse(Console.ReadLine(), out userInput) ||
                     userInput < 1 || userInput > menuItems.Count);

            menuItems[userInput - 1].Execute();
            ShowMainMenu();
        }

        private static void ClearAndShowHeading(string heading)
        {
            Console.Clear();
            Console.WriteLine(heading);
            Console.WriteLine(new string('-', heading?.Length ?? 0));
        }
    }
}
