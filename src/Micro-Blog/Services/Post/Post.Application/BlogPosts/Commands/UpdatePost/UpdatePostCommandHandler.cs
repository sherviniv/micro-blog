using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Post.Application.Common.Exceptions;
using Post.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Post.Application.BlogPosts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Unit>
    {
        private readonly IPostDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdatePostCommandHandler> _logger;

        public UpdatePostCommandHandler(
            IPostDbContext context,
            IMapper mapper,
            ILogger<UpdatePostCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Posts.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (entity == null)
            {
                throw new MicroBlogException("post_not_found",
                   $"post with id '{request.Id}' not found.", System.Net.HttpStatusCode.NotFound);
            }

            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Post {request.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
