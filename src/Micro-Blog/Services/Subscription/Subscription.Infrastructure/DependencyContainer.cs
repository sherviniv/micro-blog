using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Subscription.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Subscription.Infrastructure
{
    public static class DependencyContainer
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SubscriptionDbContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => {
                        b.MigrationsAssembly(typeof(SubscriptionDbContext).Assembly.FullName);
                        b.EnableRetryOnFailure();
                    });
            });
        }
    }
}
