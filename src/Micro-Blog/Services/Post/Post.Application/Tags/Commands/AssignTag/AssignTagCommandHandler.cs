using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Post.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Post.Application.Tags.Commands.AssignTag
{
    public class AssignTagCommandHandler : IRequestHandler<AssignTagCommand, Unit>
    {
        private readonly IPostDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AssignTagCommandHandler> _logger;

        public AssignTagCommandHandler(
            IPostDbContext context,
            IMapper mapper,
            ILogger<AssignTagCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(AssignTagCommand request, CancellationToken cancellationToken)
        {
            var tagsId = request.TagIds;

            var entity = await _context.Posts.FirstOrDefaultAsync(c => c.Id == request.PostId);

            //Remove Tags that not included in the list
            var removedTags = entity.BlogTags
                .Where(c => !tagsId.Contains(c.Id)).ToList();
            if (removedTags.Any())
            {
                removedTags.ForEach(c => entity.BlogTags.Remove(c));
            }

            //Add new tags which not included in database
            var newTagIds = tagsId
                .Where(t => entity.BlogTags.Select(c => c.Id)
                .Contains(t)).ToList();
            if (newTagIds.Any())
            {
                var tags = await _context.Tags.Where(c => newTagIds.Contains(c.Id)).ToListAsync();
                tags.ForEach(c => entity.BlogTags.Add(c));
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Tags updated on Post {entity.Id}.");

            return Unit.Value;
        }
    }
}
