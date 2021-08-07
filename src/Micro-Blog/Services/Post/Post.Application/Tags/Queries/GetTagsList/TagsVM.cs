using System.Collections.Generic;

namespace Post.Application.Tags.Queries.GetTagsList
{
    public class TagsVM
    {
        public IList<TagsVM> Tags { get; set; }

        public TagsVM(List<TagsVM> tags)
        {
            Tags = tags;
        }
    }
}
