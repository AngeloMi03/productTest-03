using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Productes { get; set; }
    }

}


