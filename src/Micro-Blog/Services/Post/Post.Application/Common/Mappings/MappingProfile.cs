using AutoMapper;
using Post.Application.BlogPosts.Commands.CreatePost;
using Post.Domain.Entities;

namespace Post.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPost, CreatePostCommand>().ReverseMap();
        }
    }
}
