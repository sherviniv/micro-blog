using EventBus.Common.Abstractions;
using EventBus.Events.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Subscription.Application.EventBusConsumers.Blog
{
    public class BlogPublishedConsumer : IEventConsumer<BlogPublishedEvent>
    {
        private readonly ILogger<BlogPublishedConsumer> _logger;

        public BlogPublishedConsumer(ILogger<BlogPublishedConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<BlogPublishedEvent> context)
        {
            _logger.LogInformation("BlogPublishedConsumer consumed successfully. ", context.Message.PublisherUserId);
        }
    }
}
