using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.IRepository;

namespace Persistence;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _dbContext;
    public ProductRepository(ProductDbContext dbContext)
    {
        _dbContext =  dbContext;
    }

    public async Task<List<Product>> getAllProduct()
    {
       List<Product> productList = await _dbContext.Productes
                                  .OrderByDescending(x => x.Date_Create)
                                  .ToListAsync();
       return productList;
    }
}
