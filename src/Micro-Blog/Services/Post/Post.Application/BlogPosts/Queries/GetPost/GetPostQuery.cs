using MediatR;

namespace Post.Application.BlogPosts.Queries.GetPost
{
    class GetPostQuery : IRequest<PostVM>
    {
        public int Id { get; set; }

        public GetPostQuery(int userName)
        {
            Id = Id;
        }
    }
}
