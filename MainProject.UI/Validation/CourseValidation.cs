using FluentValidation;
using MainProject.BL.DTO;

namespace MainProject.UI.Validation
{
    public class CourseValidation : AbstractValidator<CourseDTO>
    {
        public CourseValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(nameof(CourseDTO.Id) + " Cant be empty");
            RuleFor(x => x.Skills).NotEmpty().WithMessage(nameof(CourseDTO.Skills) + " Cant be empty");
            RuleFor(x => x.Materials).NotEmpty().WithMessage(nameof(CourseDTO.Materials) + " Cant be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage(nameof(CourseDTO.Name) + " Cant be empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage(nameof(CourseDTO.Description) + " Cant be empty");
        }
    }
}
