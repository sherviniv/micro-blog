using MediatR;

namespace Post.Application.BlogPosts.Queries.GetPostsList
{
    public class GetPostsListQuery : IRequest<PostsVM>
    {
        public string SearchTerm { get; set; }

        public GetPostsListQuery(string searchTerm)
        {
            SearchTerm = searchTerm;
        }
    }
}
