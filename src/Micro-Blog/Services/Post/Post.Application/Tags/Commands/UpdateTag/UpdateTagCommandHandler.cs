using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Post.Application.Common.Exceptions;
using Post.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Post.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Unit>
    {
        private readonly IPostDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTagCommandHandler> _logger;

        public UpdateTagCommandHandler(
            IPostDbContext context,
            IMapper mapper,
            ILogger<UpdateTagCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Tags.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (entity == null)
            {
                throw new MicroBlogException("tag_not_found",
                   $"tag with id '{request.Id}' not found.", System.Net.HttpStatusCode.NotFound);
            }

            _mapper.Map(request, entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Tag {request.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
