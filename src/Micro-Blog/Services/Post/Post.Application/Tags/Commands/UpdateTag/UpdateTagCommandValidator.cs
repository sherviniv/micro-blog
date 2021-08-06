using FluentValidation;
using Post.Application.Tags.Commands.CreateTag;

namespace Post.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
    {
        public UpdateTagCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{Id} is required.");

            RuleFor(p => p.Title)
               .NotEmpty().WithMessage("{Title} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{Title} must not exceed 50 characters.");

            RuleFor(p => p.Description)
               .MaximumLength(255).WithMessage("{Description} must not exceed 255 characters.");
        }
    }
}
