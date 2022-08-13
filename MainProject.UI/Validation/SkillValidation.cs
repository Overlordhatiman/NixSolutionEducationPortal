namespace MainProject.UI.Validation
{
    using FluentValidation;
    using MainProject.BL.DTO;

    public class SkillValidation : AbstractValidator<SkillDTO>
    {
        public SkillValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(nameof(SkillDTO.Name) + " Cant be empty");
        }
    }
}
