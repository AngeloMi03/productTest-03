using Domain;
using Moq;
using Persistence.IRepository;

namespace Tests;

public class ListProductCommandHandlerTest
{
    private readonly Mock<IProductRepository> _productRepositoryMock;

    public ListProductCommandHandlerTest()
    {
        _productRepositoryMock = new ();
    }

    [Fact]
    public async Task ListProductTest(){
       var command = new Application.List.Query();

       var handler = new  Application.List.Handler(_productRepositoryMock.Object);

       var result = await handler.Handle(command, default);

       Assert.Equal(3,result.Count);
    }

    
}
