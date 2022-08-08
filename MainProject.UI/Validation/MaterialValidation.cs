using FluentValidation;
using MainProject.BL.DTO;

namespace MainProject.UI.Validation
{
    public class MaterialValidation : AbstractValidator<MaterialsDTO>
    {
        public MaterialValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(nameof(MaterialsDTO.Id) + " Cant be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage(nameof(MaterialsDTO.Name) + " Cant be empty");
        }
    }
}
