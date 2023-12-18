using CatalogService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.DataAccess
{
    public class CatalogServiceContext : DbContext
    {
        public CatalogServiceContext(DbContextOptions<CatalogServiceContext> options)
            : base(options)
        { }

        public DbSet<CatalogItem> CatalogItems { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
