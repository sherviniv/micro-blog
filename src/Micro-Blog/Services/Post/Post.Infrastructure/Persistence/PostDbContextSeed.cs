using Post.Application.Common.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Infrastructure.Persistence
{
    public static class PostDbContextSeed
    {

        public static async Task SeedSamplePostsAsync(IPostDbContext context)
        {
            if (!context.Posts.Any())
            {
                context.Posts.Add(new()
                {
                    Created = DateTime.Now,
                    Title   = "Sample",
                    Content = "lorem ipsum",
                    CreatedBy = "seed",
                    Published = false
                }); ;
            }

            await context.SaveChangesAsync();
        }
    }
}
