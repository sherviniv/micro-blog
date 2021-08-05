using MediatR;

namespace Post.Application.BlogPosts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }

        protected DeletePostCommand()
        {
        }

        public DeletePostCommand(int id)
        {
            Id = id;
        }
    }
}
