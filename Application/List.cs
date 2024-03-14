using Domain;
using MediatR;
using Persistence.IRepository;

namespace Application
{
    public class List
    {

        public class Query : IRequest<List<Product>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Product>>
        {
            private readonly IProductRepository _productRepository;
            public Handler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<List<Product>> Handle(Query request, CancellationToken cancellationToken)
            {
                var productsList = await _productRepository.getAllProduct();

                return productsList;
            }
        }
    }

}




