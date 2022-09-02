namespace MainProject.UI.Managed
{
    using FluentValidation.Results;
    using MainProject.BL.DTO;
    using MainProject.BL.Interfaces;
    using MainProject.UI.Validation;
    using Microsoft.Extensions.DependencyInjection;

    public class UserController
    {
        private UserValidation? _userValidation;

        private IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
            _userValidation = new UserValidation();
        }

        public int IdUser { get; set; }

        public UserDTO GetUserFromConsole()
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

            return Validate(user);
        }

        public void CreateUser()
        {
            CreateUser(GetUserFromConsole());
        }

        public void UpdateUser()
        {
            int id = GetId();
            Console.WriteLine("Current object");
            Console.WriteLine(_userService.GetUser(id));

            UpdateUser(GetUserFromConsole(), id);
        }

        public UserDTO GetUser(int id)
        {
            return _userService.GetUser(id);
        }

        public UserDTO GetUser()
        {
            return _userService.GetUser(IdUser);
        }

        public void UpdateUser(UserDTO user)
        {
            UpdateUser(user, IdUser);
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

            bool isValid = _userService.IsValidUser(mail, password);

            if (isValid)
            {
                IdUser = _userService.GetUser(mail, password).Id;
            }

            return isValid;
        }

        public void OutputUser()
        {
            Console.WriteLine("User");

            Console.WriteLine(_userService.GetUser(IdUser));

            Console.ReadKey();
        }

        public void OutputUsers()
        {
            Console.WriteLine("Users");
            var users = _userService.GetAllUser();

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.ReadKey();
        }

        private UserDTO Validate(UserDTO user)
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

        private void UpdateUser(UserDTO user, int id)
        {
            if (user == null)
            {
                return;
            }

            user.Id = id;
            _userService.UpdateUser(user);
        }

        private void DeleteUser(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
