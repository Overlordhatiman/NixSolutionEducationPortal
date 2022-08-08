using FluentValidation;
using MainProject.BL.DTO;

namespace MainProject.UI.Validation
{
    public class ArticleValidation : AbstractValidator<ArticleDTO>
    {
        public ArticleValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(nameof(ArticleDTO.Id) + " Cant be empty");
            RuleFor(x => x.Date).NotEmpty().WithMessage(nameof(ArticleDTO.Date) + " Cant be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage(nameof(ArticleDTO.Name) + " Cant be empty");
        }
    }
}
