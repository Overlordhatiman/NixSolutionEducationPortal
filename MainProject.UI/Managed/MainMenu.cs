﻿namespace MainProject.UI.Managed
{
    public class MainMenu
    {
        private List<MenuItem> _mainMenu;

        private List<MenuItem> _courseMenu;

        private List<MenuItem> _materialsMenu;

        private List<MenuItem> _userMenu;

        private List<MenuItem> _skillMenu;

        private MaterialsController _materialsCRUD;

        private CourseController _courseCRUD;

        private SkillController _skillCRUD;

        private UserController _userCRUD;

        public MainMenu(MaterialsController materialsCRUD, CourseController courseCRUD, SkillController skillCRUD, UserController userCRUD)
        {
            _materialsCRUD = materialsCRUD;
            _courseCRUD = courseCRUD;
            _skillCRUD = skillCRUD;
            _userCRUD = userCRUD;

            _mainMenu = new List<MenuItem>
            {
                new MenuItem { Description = "Course", Execute = ShowCourseMenu },
                new MenuItem { Description = "Materials", Execute = ShowMaterialsMenu },
                new MenuItem { Description = "Skills", Execute = ShowSkillMenu },
                new MenuItem { Description = "Start course", Execute = ShowSkillMenu },
                new MenuItem { Description = "Log out", Execute = LogOut },
            };

            _materialsMenu = new List<MenuItem>
            {
                new MenuItem { Description = "Create", Execute = _materialsCRUD.CreateMaterial },
                new MenuItem { Description = "Delete", Execute = _materialsCRUD.DeleteMaterial },
                new MenuItem { Description = "Update", Execute = _materialsCRUD.UpdateMaterial },
                new MenuItem { Description = "Output", Execute = _materialsCRUD.OutputMaterials },
                new MenuItem { Description = "Log out", Execute = LogOut },
            };

            _courseMenu = new List<MenuItem>
            {
                new MenuItem { Description = "Create", Execute = _courseCRUD.CreateCourse },
                new MenuItem { Description = "Delete", Execute = _courseCRUD.DeleteCourse },
                new MenuItem { Description = "Update", Execute = _courseCRUD.UpdateCourse },
                new MenuItem { Description = "Output", Execute = _courseCRUD.OutputCourse },
                new MenuItem { Description = "Log out", Execute = LogOut },
            };

            _skillMenu = new List<MenuItem>
            {
                new MenuItem { Description = "Create", Execute = _skillCRUD.CreateSkill},
                new MenuItem { Description = "Delete", Execute = _skillCRUD.DeleteSkill },
                new MenuItem { Description = "Update", Execute = _skillCRUD.UpdateSkill },
                new MenuItem { Description = "Output", Execute = _skillCRUD.OutputSkills },
                new MenuItem { Description = "Log out", Execute = LogOut },
            };

            _userMenu = new List<MenuItem>
            {
                new MenuItem { Description = "Create", Execute = _userCRUD.CreateUser },
                new MenuItem { Description = "LogIn", Execute = LogIn},
            };
        }

        public void ShowMainMenu()
        {
            Menu(_mainMenu, "Main Menu");
        }

        public void ShowSkillMenu()
        {
            Menu(_skillMenu, "Skill Menu");
            ShowMainMenu();
        }

        public void ShowRegisterMenu()
        {
            Menu(_userMenu, "Register menu");
            ShowRegisterMenu();
        }

        public void ShowRegisterMenu(string error)
        {
            Menu(_userMenu, error);
        }

        public void ShowCourseMenu()
        {
            Menu(_courseMenu, "Course menu");
            ShowMainMenu();
        }

        public void ShowMaterialsMenu()
        {
            Menu(_materialsMenu, "Material menu");
            ShowMainMenu();
        }

        private static void ClearAndShowHeading(string heading)
        {
            Console.Clear();
            Console.WriteLine(heading);
            Console.WriteLine(new string('-', heading?.Length ?? 0));
        }

        private void LogIn()
        {
            if (_userCRUD.IsValid())
            {
                ShowMainMenu();
            }
            else
            {
                ShowRegisterMenu("**Error** Undefiend user");
            }
        }

        private void LogOut()
        {
            _userCRUD.CurrentUser = null;
            ShowRegisterMenu();
        }

        private void Menu(List<MenuItem> menuItems, string message)
        {
            ClearAndShowHeading(message);

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
            }
            while (!int.TryParse(Console.ReadLine(), out userInput) ||
                     userInput < 1 || userInput > menuItems.Count);

            menuItems[userInput - 1].Execute();
        }
    }
}
