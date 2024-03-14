using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence.Data
{
    public class DbInitializer
    {
        public static async Task SeedData(ProductDbContext context)
        {
            if (!context.Productes.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Product1",
                        Matricule = "123",
                        Slug = new Guid(),
                        Date_Create = DateTime.Now,
                        Date_Edit = DateTime.Now
                    },
                    new Product
                    {
                        Name = "Product3",
                        Matricule = "123",
                        Slug = new Guid(),
                        Date_Create = DateTime.Now,
                        Date_Edit = DateTime.Now
                    },
                    new Product
                    {
                        Name = "Product3",
                        Matricule = "123",
                        Slug = new Guid(),
                        Date_Create = DateTime.Now,
                        Date_Edit = DateTime.Now
                    }
                    
                };

                await context.Productes.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}