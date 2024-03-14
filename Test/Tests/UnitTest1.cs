using Domain;
using Moq;
using Persistence.IRepository;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests
{
    public class ListProductCommandHandlerTest 
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public ListProductCommandHandlerTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
        }

        [Fact]
        public async Task ListProductTest()
        {
            // var command = new Application.List.Query();

            // var handler = new Application.List.Handler(_productRepositoryMock.Object);

            // List<Product> result = await handler.Handle(command, default);

            // Console.Write("result" + result);

            // Assert.Equal(3, result.Count);

        }


    }
}


