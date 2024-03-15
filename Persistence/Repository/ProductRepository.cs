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

        public async Task addProduct(Product product) //ProductDtO
        {

            await _dbContext.Productes.AddAsync(product);

        }

        public void deleteProduct(Product product)
        {
            _dbContext.Productes.Remove(product);

        }

        public async Task<IQueryable<Product>> getAllProductasQuerable()
        {
            IQueryable<Product> productList = _dbContext.Productes.AsQueryable();
                                    //     .OrderByDescending(x => x.Date_Create)
                                    //    .AsQueryable();
            return productList;
        }

        public async Task<bool> Complete()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> findProductByMatricule(Product product)
        {
            return await _dbContext.Productes.AnyAsync(x => x.Matricule == product.Matricule);
        }

        public async Task<Product> findProductBySlug(Guid slug)
        {
            return await _dbContext.Productes
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Slug == slug);
        }

        public void editProduct(Product product)  ///productDto
        {
             _dbContext.Entry(product).State = EntityState.Modified;
        }
    }
}


