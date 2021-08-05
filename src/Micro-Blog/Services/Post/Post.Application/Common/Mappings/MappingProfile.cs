using AutoMapper;
using Post.Application.BlogPosts.Commands.CreatePost;
using Post.Application.BlogPosts.Queries.GetPost;
using Post.Domain.Entities;

namespace Post.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPost, CreatePostCommand>().ReverseMap();

            CreateMap<BlogPost, PostVM>().ReverseMap();
        }
    }
}
