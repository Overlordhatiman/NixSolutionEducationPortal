namespace MainProject.UI.Validation
{
    using FluentValidation;
    using MainProject.BL.DTO;

    public class ArticleValidation : AbstractValidator<ArticleDTO>
    {
        public ArticleValidation()
        {
            RuleFor(x => x.Date).NotEmpty().WithMessage(nameof(ArticleDTO.Date) + " Cant be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage(nameof(ArticleDTO.Name) + " Cant be empty");
        }
    }
}
