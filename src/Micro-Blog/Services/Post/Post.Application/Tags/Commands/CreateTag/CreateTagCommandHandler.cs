using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Post.Application.Common.Interfaces;
using Post.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Post.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, int>
    {
        private readonly IPostDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateTagCommandHandler> _logger;

        public CreateTagCommandHandler(
            IPostDbContext context,
            IMapper mapper,
            ILogger<CreateTagCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Tag>(request);
            _context.Tags.Add(entity);

            await _context.SaveChangesAsync();
            _logger.LogInformation($"Tag {entity.Id} is successfully created.");

            return entity.Id;
        }
    }
}
