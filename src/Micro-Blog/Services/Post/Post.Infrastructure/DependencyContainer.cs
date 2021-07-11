using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Post.Application.Common.Interfaces;
using Post.Infrastructure.Persistence;
using System;

namespace Post.Infrastructure
{
    public  static class DependencyContainer
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<PostDbContext>((serviceProvider, options) =>
            {
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 25)),
                    b => {
                        b.MigrationsAssembly(typeof(PostDbContext).Assembly.FullName);
                        b.EnableRetryOnFailure();
                    });
            });


            services.AddScoped<IPostDbContext>(provider => provider.GetService<PostDbContext>());
        }
    }
}
