using Microsoft.EntityFrameworkCore;
using Post.Application.Common.Interfaces;
using Post.Domain.Common;
using Post.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Post.Infrastructure.Persistence
{
    public class PostDbContext : DbContext, IPostDbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "some id";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "some id";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        //Add-Migration InitialCreate -OutputDir "Persistence/Migrations"
    }
}
