namespace MainProject.UI.Managed
{
    using FluentValidation.Results;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.UI.Validation;
    using Microsoft.Extensions.DependencyInjection;

    public class UserCRUD
    {
        private static UserValidation? _userValidation;

        private IUserService _userService;

        public UserCRUD(IUserService service)
        {
            _userService = service;
            _userValidation = new UserValidation();
        }

        public static UserDTO GetUser()
        {
            Console.WriteLine("Input Mail");
            string? mail = Console.ReadLine();

            Console.WriteLine("Input password");
            string? password = Console.ReadLine();

            UserDTO user = new UserDTO
            {
                Mail = mail,
                Password = password,
            };

            return ValidateMaterial(user);
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
            Console.WriteLine("Input mail");
            string? mail = Console.ReadLine();

            Console.WriteLine("Input password");
            string? password = Console.ReadLine();

            return _userService.IsValidUser(mail, password);
        }

        public void OutputUser()
        {
            Console.WriteLine("Users");
            var collection = _userService.GetAllUser();

            foreach (var item in collection)
            {
                Console.WriteLine(item.Id + "\t" + item.Mail + "\t" + item.Password);
            }

            Console.ReadKey();
        }

        private static UserDTO ValidateMaterial(UserDTO user)
        {
            ValidationResult validationResult = _userValidation.Validate(user);

            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            Console.ReadKey();

            if (validationResult.IsValid)
            {
                return user;
            }

            return null;
        }

        private int GetId()
        {
            Console.WriteLine("Input ID");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            return id;
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
