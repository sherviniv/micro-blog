using Post.Application.BlogPosts.Queries.GetPost;
using System.Collections.Generic;

namespace Post.Application.BlogPosts.Queries.GetPostsList
{
    public class PostsVM
    {
        public IList<PostVM> Posts { get; set; }

        public PostsVM(List<PostVM> posts)
        {
            Posts = posts;
        }
    }
}
