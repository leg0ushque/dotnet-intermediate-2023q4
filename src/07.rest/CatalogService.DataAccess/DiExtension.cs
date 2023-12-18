using CatalogService.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.DataAccess
{
    public static class DiExtension
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            return services
                .AddDbContext<CatalogServiceContext>(options =>
                {
                    if (string.IsNullOrEmpty(connectionString))
                    {
                        options.UseInMemoryDatabase(nameof(CatalogService));
                    }
                    else
                    {
                        options.UseSqlServer(connectionString);
                    }
                })
                .AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}
