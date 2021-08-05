using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Post.Application.Common.Exceptions;
using Post.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Post.Application.BlogPosts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostDbContext _context;
        private readonly ILogger<DeletePostCommandHandler> _logger;

        public DeletePostCommandHandler(
            IPostDbContext context,
            ILogger<DeletePostCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Posts.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (entity == null)
            {
                throw new MicroBlogException("post_not_found",
                   $"post with id '{request.Id}' not found.", System.Net.HttpStatusCode.NotFound);
            }

            _context.Posts.Remove(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Post {request.Id} is deleted.");

            return Unit.Value;
        }
    }
}
