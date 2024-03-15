using Domain;

namespace Persistence.IRepository
{
    public interface IProductRepository
    {
        Task<IQueryable<Product>> getAllProductasQuerable();
        Task addProduct(Product product);
        void deleteProduct(Product product);
        Task<bool> Complete();
        Task<bool> findProductByMatricule(Product product);
        Task<Product> findProductBySlug(Guid slug);
        void editProduct(Product product);
    }

}


