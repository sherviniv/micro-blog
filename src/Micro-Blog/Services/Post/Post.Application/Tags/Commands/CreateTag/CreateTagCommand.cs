using MediatR;

namespace Post.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
