using FluentValidation;
using MainProject.BL.DTO;

namespace MainProject.UI.Validation
{
    public class VideoValidation : AbstractValidator<VideoDTO>
    {
        public VideoValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(nameof(VideoDTO.Id) + " Cant be empty");
            RuleFor(x => x.Quality).NotEmpty().WithMessage(nameof(VideoDTO.Quality) + " Cant be empty");
            RuleFor(x => x.Time).NotEmpty().WithMessage(nameof(VideoDTO.Time) + " Cant be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage(nameof(VideoDTO.Name) + " Cant be empty");
        }
    }
}
