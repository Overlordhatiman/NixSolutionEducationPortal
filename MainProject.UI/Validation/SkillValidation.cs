using FluentValidation;
using MainProject.BL.DTO;

namespace MainProject.UI.Validation
{
    public class SkillValidation : AbstractValidator<SkillDTO>
    {
        public SkillValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(nameof(SkillDTO.Id) + " Cant be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage(nameof(SkillDTO.Name) + " Cant be empty");
        }
    }
}
