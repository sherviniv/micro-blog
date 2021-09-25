using Microsoft.EntityFrameworkCore;
using Subscription.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Subscription.Application.Common.Interfaces
{
    public interface ISubscriptionDbContext
    {
        public DbSet<BlogSubscription> BlogSubscriptions { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
