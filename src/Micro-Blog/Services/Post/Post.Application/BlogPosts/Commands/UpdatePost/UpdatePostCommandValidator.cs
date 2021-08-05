using FluentValidation;

namespace Post.Application.BlogPosts.Commands.UpdatePost
{
    public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.");

            RuleFor(p => p.Title)
              .NotEmpty().WithMessage("{Title} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{Title} must not exceed 50 characters.");

            RuleFor(p => p.Content)
               .NotEmpty().WithMessage("{Content} is required.");
        }
    }
}
