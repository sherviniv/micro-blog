using Microsoft.EntityFrameworkCore;
using Post.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Post.Application.Common.Interfaces
{
    public interface IPostDbContext
    {
        DbSet<BlogPost> Posts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
