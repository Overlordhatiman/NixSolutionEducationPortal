using FluentValidation;
using MainProject.BL.DTO;

namespace MainProject.UI.Validation
{
    public class UserValidation : AbstractValidator<UserDTO>
    {
        public UserValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(nameof(VideoDTO.Id) + " Cant be empty");
            RuleFor(x => x.Mail).NotEmpty().EmailAddress().WithMessage(nameof(VideoDTO.Quality) + " Cant be empty");
            RuleFor(x => x.Password).NotEmpty().Equal(x => x.Password).WithMessage(nameof(VideoDTO.Time) + " Cant be empty");
        }
    }
}
