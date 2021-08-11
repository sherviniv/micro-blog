using FluentValidation;

namespace Post.Application.Tags.Commands.AssignTag
{
    public class AssignTagCommandValidator : AbstractValidator<AssignTagCommand>
    {
        public AssignTagCommandValidator()
        {
            RuleFor(p => p.PostId)
             .NotEmpty().WithMessage("{Id} is required.");

           // RuleFor(p => p.TagIds)
           // .Must(c=> c.Count < 1).WithMessage("At least one of 1 tags should be selected");
        }
    }
}
