using AutoMapper;
using MediatR;
using Post.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Post.Application.BlogPosts.Queries.GetPostsList;
using AutoMapper.QueryableExtensions;
using Post.Application.BlogPosts.Queries.GetPost;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Post.Application.BlogPosts.Queries.GetPostsByTag
{
    public class GetPostsByTagQueryHandler : IRequestHandler<GetPostsByTagQuery, PostsVM>
    {
        private readonly IMapper _mapper;
        private readonly IPostDbContext _context;

        public GetPostsByTagQueryHandler(
            IPostDbContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PostsVM> Handle(GetPostsByTagQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Posts
                .Where(p => p.BlogTags.Any(c => c.Id == request.TagId))
                .ProjectTo<PostVM>(_mapper.ConfigurationProvider)
                .ToListAsync();

            PostsVM vm = new(result);
            return vm;
        }
    }
}
