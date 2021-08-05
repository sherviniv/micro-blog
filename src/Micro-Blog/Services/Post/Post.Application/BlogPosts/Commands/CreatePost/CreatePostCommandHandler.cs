using AutoMapper;
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

        public CreatePostCommandHandler(
            IPostDbContext context,
            IMapper mapper,
            ILogger<CreatePostCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        async Task<int> IRequestHandler<CreatePostCommand, int>.Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BlogPost>(request);
            await _context.Posts.AddAsync(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Post {entity.Id} is successfully created.");
            //Todo: raise event for subscriber service
            return entity.Id;
        }
    }
}
