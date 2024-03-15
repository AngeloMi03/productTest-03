using Domain;

namespace Persistence.IRepository
{
    public interface IProductRepository
    {
        Task<IQueryable<Product>> getAllProduct();

        Task<bool?> addProduct(Product product);
    }

}


