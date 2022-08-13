namespace MainProject.UI.Validation
{
    using FluentValidation;
    using MainProject.BL.DTO;

    public class UserValidation : AbstractValidator<UserDTO>
    {
        public UserValidation()
        {
            RuleFor(x => x.Mail).NotEmpty().EmailAddress().WithMessage(nameof(VideoDTO.Quality) + " Cant be empty");
            RuleFor(x => x.Password).NotEmpty().Equal(x => x.Password).WithMessage(nameof(VideoDTO.Time) + " Cant be empty");
        }
    }
}
