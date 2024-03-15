using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence.IRepository;

namespace Application.Helpers
{
    public class Edit
    {
        public record Command : IRequest<Result<Unit>>
        {
            public Product? Product { get; set; }
        }

        internal sealed class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IProductRepository _productRepository;
            public Handler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.findProductBySlug(request.Product!.Slug);

                if(product == null) return Result<Unit>.Failure("Product not found");


                 request.Product.Date_Edit = DateTime.Now;
                 
                  //_mapper.Map(request.Product, product);
                  // _productRepository.editProduct( product);

                _productRepository.editProduct(request.Product);

                var Success = await _productRepository.Complete();

                var result = Success switch
                {
                    true => Result<Unit>.Success(Unit.Value),
                    _ => Result<Unit>.Failure("Failed to update product"),
                };

                return result;

            }
        }
    }
}