using Domain;

namespace Persistence.IRepository;


public interface IProductRepository
{
     Task<List<Product>> getAllProduct();
}
