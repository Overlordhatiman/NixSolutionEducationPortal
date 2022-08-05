namespace MainProject.UI.Managed
{
    using FluentValidation.Results;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.UI.Validation;
    using Microsoft.Extensions.DependencyInjection;

    public class UserCRUD
    {

        private IUserService _userService;

        private static UserValidation _userValidation;

        public UserCRUD(IUserService service)
        {
            _userService = service;
            _userValidation = new UserValidation();
        }

        public void CreateUser()
        {
            CreateUser(GetUser());
        }

        public void UpdateUser()
        {
            UpdateUser(GetUser());
        }

        public void DeleteUser()
        {
            DeleteUser(GetId());
        }

        public bool IsValid()
        {
            var collection = _userService.GetAllUser();

            Console.WriteLine("Input mail");
            string mail = Console.ReadLine();

            Console.WriteLine("Input password");
            string password = Console.ReadLine();

            return _userService.IsValidUser(mail, password);
        }

        public void OutputMaterials()
        {
            Console.WriteLine("Users");
            var collection = _userService.GetAllUser();

            foreach (var item in collection)
            {
                Console.WriteLine(item.Id + "\t" + item.Mail + "\t" + item.Password);
            }

            Console.ReadKey();
        }

        private int GetId()
        {
            Console.WriteLine("Input ID");
            int id;
            Int32.TryParse(Console.ReadLine(), out id);

            return id;
        }

        public static UserDTO GetUser()
        {
            Console.WriteLine("Input ID");
            int id;
            Int32.TryParse(Console.ReadLine(), out id);

            Console.WriteLine("Input Name");
            string s = Console.ReadLine();

            Console.WriteLine("Input password");
            string password = Console.ReadLine();

            UserDTO user = new UserDTO
            {
                Id = id,
                Mail = s,
                Password = password,
            };

            return ValidateMaterial(user);
        }

        private static UserDTO ValidateMaterial(UserDTO user)
        {
            ValidationResult validationResult = _userValidation.Validate(user);

            foreach (var item in validationResult.Errors)
            {
                Console.WriteLine(item.ErrorMessage);
            }

            Console.ReadKey();

            if (validationResult.IsValid)
            {
                return user;
            }

            return null;
        }

        private void CreateUser(UserDTO user)
        {
            if (user == null)
            {
                return;
            }
            _userService.AddUser(user);
        }

        private void UpdateUser(UserDTO user)
        {
            if (user == null)
            {
                return;
            }
            _userService.UpdateUser(user.Id, user);
        }

        private void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
