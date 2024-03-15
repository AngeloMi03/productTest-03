using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers;
using MediatR;
using Persistence.IRepository;

namespace Application
{
    public class Delete
    {
        public record Command : IRequest<Result<Unit>>
        {
            public Guid Slug { get; set; } //DTO
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
                var product = await _productRepository.findProductBySlug(request.Slug);

                if(product == null) return Result<Unit>.Failure("Product not found");

                _productRepository.deleteProduct(product);

                bool Success = await _productRepository.Complete();

                var result = Success switch
                {
                    true => Result<Unit>.Success(Unit.Value),
                    _ => Result<Unit>.Failure("Product removed successfuly"),
                };

                return result;
            }
        }
    }
}