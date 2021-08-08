using MediatR;
using System.Collections.Generic;

namespace Post.Application.Tags.Commands.AssignTag
{
    public class AssignTagCommand : IRequest<Unit>
    {
        public int PostId { get; set; }
        public IList<int> TagIds { get; set; }

        protected AssignTagCommand()
        {
        }

        public AssignTagCommand(int postId, IList<int> tagIds)
        {
            (PostId, TagIds) = (postId, tagIds);
        }
    }
}
