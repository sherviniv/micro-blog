using EventBus.Common.Abstractions;
using EventBus.Common.Models;
using MassTransit;
using MassTransit.Transports;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace EventBus.Common.Extensions
{
    public static class UseEventBusExtension
    {
        public static void UseEventBus(this IServiceCollection services, EventBusSetting setting, List<ConsumerDetail> consumers)
        {
            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config =>
            {
                foreach (var consumer in consumers)
                {
                    consumer.Consumers.ForEach(c => config.AddConsumer(c));
                    //config.AddConsumer<sampleConsumer>();
                }

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(setting.HostName);
                    foreach (var consumer in consumers)
                    {
                        consumer.Consumers.ForEach(cn => 
                        {
                            cfg.ReceiveEndpoint(consumer.QueueName, c =>
                            {
                                c.ConfigureConsumer(ctx,cn);
                            });
                        });
                    }
                });
            });
            services.AddMassTransitHostedService();
        }
    }
}
