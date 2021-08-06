using MediatR;

namespace Post.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }    
        public string Description { get; set; }
    }
}
