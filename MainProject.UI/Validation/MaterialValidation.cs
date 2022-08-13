namespace MainProject.UI.Validation
{
    using FluentValidation;
    using MainProject.BL.DTO;

    public class MaterialValidation : AbstractValidator<MaterialsDTO>
    {
        public MaterialValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(nameof(MaterialsDTO.Name) + " Cant be empty");
        }
    }
}
