using MediatR;

namespace Post.Application.BlogPosts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Img { get; set; }
        public bool Published { get; set; }
    }
}
