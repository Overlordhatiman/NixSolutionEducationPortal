namespace MainProject.UI.Validation
{
    using FluentValidation;
    using MainProject.BL.DTO;

    public class BookValidation : AbstractValidator<BookDTO>
    {
        public BookValidation()
        {
            RuleFor(x => x.Date).NotEmpty().WithMessage(nameof(BookDTO.Date) + " Cant be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage(nameof(BookDTO.Name) + " Cant be empty");
            RuleFor(x => x.Author).NotEmpty().WithMessage(nameof(BookDTO.Author) + " Cant be empty");
            RuleFor(x => x.Format).NotEmpty().WithMessage(nameof(BookDTO.Format) + " Cant be empty");
            RuleFor(x => x.NumberOfPages).NotEmpty().WithMessage(nameof(BookDTO.NumberOfPages) + " Cant be empty");
        }
    }
}
