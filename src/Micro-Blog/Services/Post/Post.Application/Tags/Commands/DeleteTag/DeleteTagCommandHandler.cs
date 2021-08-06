using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Post.Application.Common.Exceptions;
using Post.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Post.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand>
    {
        private readonly IPostDbContext _context;
        private readonly ILogger<DeleteTagCommandHandler> _logger;

        public DeleteTagCommandHandler(
            IPostDbContext context,
            ILogger<DeleteTagCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Tags.FirstOrDefaultAsync(t => t.Id == request.Id);
            if (entity == null)
            {
                throw new MicroBlogException("tag_not_found",
                   $"tag with id '{request.Id}' not found.", System.Net.HttpStatusCode.NotFound);
            }

            _context.Tags.Remove(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Tag {request.Id} is deleted.");

            return Unit.Value;
        }
    }
}
