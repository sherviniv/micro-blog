using MediatR;
using Post.Application.BlogPosts.Queries.GetPostsList;

namespace Post.Application.BlogPosts.Queries.GetPostsByTag
{
    public class GetPostsByTagQuery : IRequest<PostsVM>
    {
        public int TagId { get; set; }

        public GetPostsByTagQuery(int tagId)
        {
            TagId = tagId;
        }
    }
}
