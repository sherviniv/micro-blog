using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Post.Application.Common.Exceptions;
using Post.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Post.Application.BlogPosts.Queries.GetPost
{
    class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostVM>
    {
        private readonly IMapper _mapper;
        private readonly IPostDbContext _context;

        public GetPostQueryHandler(
            IPostDbContext context,
            IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PostVM> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            PostVM vm = default; 
            var entity = await _context.Posts.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (entity == null)
            {
                throw new MicroBlogException("post_not_found",
                   $"post with id '{request.Id}' not found.", System.Net.HttpStatusCode.NotFound);
            }

            _mapper.Map(entity, vm);
            return vm;
        }
    }
}
