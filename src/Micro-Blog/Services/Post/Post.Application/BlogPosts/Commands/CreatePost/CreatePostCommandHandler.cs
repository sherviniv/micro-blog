using AutoMapper;
using EventBus.Common.Abstractions;
using EventBus.Events.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Post.Application.Common.Interfaces;
using Post.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Post.Application.BlogPosts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IPostDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePostCommandHandler> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreatePostCommandHandler(
            IPostDbContext context,
            IMapper mapper,
            IPublishEndpoint publishEndpoint,
            ILogger<CreatePostCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        async Task<int> IRequestHandler<CreatePostCommand, int>.Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BlogPost>(request);
            await _context.Posts.AddAsync(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Post {entity.Id} is successfully created.");

            if (entity.Published)
            {
                await _publishEndpoint.Publish(new BlogPublishedEvent("notimpelemented-userid"));
            }

            return entity.Id;
        }
    }
}
