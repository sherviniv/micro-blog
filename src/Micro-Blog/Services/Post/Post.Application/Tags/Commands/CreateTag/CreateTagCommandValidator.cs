using FluentValidation;

namespace Post.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(p => p.Title)
               .NotEmpty().WithMessage("{Title} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{Title} must not exceed 50 characters.");

            RuleFor(p => p.Description)
               .MaximumLength(255).WithMessage("{Description} must not exceed 255 characters.");
        }
    }
}
