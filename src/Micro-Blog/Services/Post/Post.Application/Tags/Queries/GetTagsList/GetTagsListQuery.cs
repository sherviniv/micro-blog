using MediatR;

namespace Post.Application.Tags.Queries.GetTagsList
{
    public class GetTagsListQuery : IRequest<TagsVM>
    {
        public string SearchTerm { get; set; }

        public GetTagsListQuery(string searchTerm)
        {
            SearchTerm = searchTerm;
        }
    }
}
