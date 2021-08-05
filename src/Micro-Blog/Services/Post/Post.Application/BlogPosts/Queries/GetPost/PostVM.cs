using System;

namespace Post.Application.BlogPosts.Queries.GetPost
{
    public class PostVM
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Img { get; set; }
        public bool Published { get; set; }
    }
}
