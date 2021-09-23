using EventBus.Common.Constants;
using EventBus.Common.Extensions;
using EventBus.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Subscription.Application.EventBusConsumers.Blog;
using System.Collections.Generic;

namespace Subscription.Application
{
    public static class DependencyContainer
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.UseEventBus(new(configuration["EventBusSettings:HostAddress"]), new List<ConsumerDetail>()
            {
                new ConsumerDetail() 
                {
                     QueueName= EventBusConstants.BlogPublishedQueue,
                     Consumers = new List<System.Type>{ typeof(BlogPublishedConsumer) } 
                }
            });
        }
    }
}
