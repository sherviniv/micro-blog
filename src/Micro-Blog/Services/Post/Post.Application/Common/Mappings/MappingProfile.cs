using AutoMapper;
using Post.Application.BlogPosts.Commands.CreatePost;
using Post.Application.BlogPosts.Commands.UpdatePost;
using Post.Application.BlogPosts.Queries.GetPost;
using Post.Application.Tags.Commands.CreateTag;
using Post.Application.Tags.Commands.UpdateTag;
using Post.Application.Tags.Queries.GetTag;
using Post.Domain.Entities;

namespace Post.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPost, CreatePostCommand>().ReverseMap();
            CreateMap<BlogPost, UpdatePostCommand>().ReverseMap();
            CreateMap<BlogPost, PostVM>().ReverseMap();

            CreateMap<Tag, CreateTagCommand>().ReverseMap();
            CreateMap<Tag, UpdateTagCommand>().ReverseMap();
            CreateMap<Tag, TagVM>().ReverseMap();
        }
    }
}
