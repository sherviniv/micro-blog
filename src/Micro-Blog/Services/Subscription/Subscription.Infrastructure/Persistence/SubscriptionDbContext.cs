using Microsoft.EntityFrameworkCore;
using Subscription.Domain.Entities;

namespace Subscription.Infrastructure.Persistence
{
    public class SubscriptionDbContext : DbContext
    {
        public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options) : base(options: options)
        {
        }

        public DbSet<BlogSubscription> BlogSubscriptions { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
    }
}
