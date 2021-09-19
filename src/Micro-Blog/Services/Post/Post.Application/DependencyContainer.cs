using EventBus.Common.Extensions;
using EventBus.Common.Models;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Post.Application.Common.Behaviours;
using System.Collections.Generic;
using System.Reflection;

namespace Post.Application
{
    public static class DependencyContainer
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.UseEventBus(new(configuration["EventBusSettings:HostAddress"]), new List<ConsumerDetail>());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}
