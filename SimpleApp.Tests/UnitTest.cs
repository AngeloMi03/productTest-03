using Domain;
using Persistence.IRepository;
using Moq;


namespace SimpleApp.Tests;

public class UnitTest
{
        private readonly Mock<IProductRepository> _productRepositoryMock;  

        public UnitTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            
        }

        

        [Fact]
        public async Task ListProductTest()
        {
            var command = new Application.List.Query();

            var handler = new Application.List.Handler(_productRepositoryMock.Object);

            var result = await handler.Handle(command, default);

            Assert.True(result.IsSucces);

        }
    
}