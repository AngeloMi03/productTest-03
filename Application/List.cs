using Application.Helpers;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.IRepository;

namespace Application
{
    public class List
    {

        public class Query : IRequest<Result<PaginationList<Product>>>
        {
            public  ParamsPagination pageParmams { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PaginationList<Product>>>
        {
            private readonly IProductRepository _productRepository;
            public Handler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<Result<PaginationList<Product>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var productsList = await _productRepository.getAllProductasQuerable();

                var  query = productsList.OrderByDescending(x => x.Date_Create);
                
                return Result<PaginationList<Product>>.Success(
                     await PaginationList<Product>.createAsync(query, 
                      request.pageParmams.PageNumber, request.pageParmams.PageSize)
                );
            }
        }
    }

}




