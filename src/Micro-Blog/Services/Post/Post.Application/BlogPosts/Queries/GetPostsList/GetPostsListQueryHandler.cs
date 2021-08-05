using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Post.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Post.Application.BlogPosts.Queries.GetPost;

namespace Post.Application.BlogPosts.Queries.GetPostsList
{
    public class GetPostsListQueryHandler : IRequestHandler<GetPostsListQuery, PostsVM>
    {
        private readonly IMapper _mapper;
        private readonly IPostDbContext _context;

        public GetPostsListQueryHandler(
            IPostDbContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PostsVM> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
        {
            PostsVM vm = default;
            var result = _context.Posts.AsQueryable();

            var search = request.SearchTerm;
            if (string.IsNullOrEmpty(search))
            {
                result = result.Where(p => p.Title.Contains(search)
                                        || p.Content.Contains(search));
            }
            vm = new(
                await result.ProjectTo<PostVM>(_mapper.ConfigurationProvider)
                            .ToListAsync());

            return vm;
        }
    }
}
