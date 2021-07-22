using FluentValidation;

namespace Post.Application.BlogPosts.Commands.CreatePost
{
    class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(p => p.Title)
               .NotEmpty().WithMessage("{Title} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{Title} must not exceed 50 characters.");

            RuleFor(p => p.Content)
               .NotEmpty().WithMessage("{Content} is required.");
        }
    }
}
