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
                bool product = await _productRepository.findProductByMatricule(request.Product!);

                if(product) return Result<Unit>.Failure("Product already exist");

                var newProduct = new Product
                {
                    Slug = new Guid(),
                    Name = request.Product!.Name,
                    Matricule = request.Product.Matricule,
                    Date_Create = DateTime.Now,
                    Date_Edit = DateTime.Now
                };

                await _productRepository.addProduct(newProduct);

                var Success = await _productRepository.Complete();

                var result = Success switch
                {
                    true => Result<Unit>.Success(Unit.Value),
                    _ => Result<Unit>.Failure("Failed to Add product"),
                };

                return result;
            }
        }
    }
}