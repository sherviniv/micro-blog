using Post.Domain.Common;
using System.Collections.Generic;

namespace Post.Domain.Entities
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Img { get; set; }
        public bool Published { get; set; }

        public virtual ICollection<Tag> BlogTags { get; set; }

        public BlogPost()
        {
        }
    }
}
