using Post.Application.Tags.Queries.GetTag;
using System.Collections.Generic;

namespace Post.Application.Tags.Queries.GetTagsList
{
    public class TagsVM
    {
        public IList<TagVM> Tags { get; set; }

        public TagsVM(List<TagVM> tags)
        {
            Tags = tags;
        }
    }
}
