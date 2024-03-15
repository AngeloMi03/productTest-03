using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers;
using Domain;
using MediatR;
using Persistence.IRepository;

namespace Application
{
    public class Add
    {
        public record Command : IRequest<Result<Unit>>
        {
            public Product? Product { get; set; } //DTO
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
                bool? IsSucces = await _productRepository.addProduct(request.Product!);

                var result = IsSucces switch
                {
                    true => Result<Unit>.Success(Unit.Value),
                    false => Result<Unit>.Failure("Failed to Add product"),
                    _ => Result<Unit>.Failure("Product already exist")
                };

                return result;
            }
        }
    }
}