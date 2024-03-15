using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.IRepository;

namespace Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;
        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool?> addProduct(Product product) //ProductDtO
        {
            var p = await _dbContext.Productes.AnyAsync(x => x.Matricule == product.Matricule);

            if(p == true) return null;

            var newProduct = new Product
            {
                Slug = new Guid(),
                Name = product.Name,
                Matricule = product.Matricule,
                Date_Create = DateTime.Now,
                Date_Edit = DateTime.Now
            };

            _dbContext.Productes.Add(newProduct);

            bool result = await _dbContext.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<IQueryable<Product>> getAllProduct()
        {
            IQueryable<Product> productList = _dbContext.Productes
                                       .OrderByDescending(x => x.Date_Create)
                                       .AsQueryable();
            return productList;
        }
    }
}


