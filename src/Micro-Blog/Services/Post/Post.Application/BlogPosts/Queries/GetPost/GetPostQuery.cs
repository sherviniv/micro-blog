using MediatR;

namespace Post.Application.BlogPosts.Queries.GetPost
{
    public class GetPostQuery : IRequest<PostVM>
    {
        public int Id { get; set; }

        public GetPostQuery(int userName)
        {
            Id = Id;
        }
    }
}
