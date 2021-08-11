using Post.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
