using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Moq;
using Persistence.IRepository;
using Microsoft.AspNetCore.Mvc.Testing;
using Domain;

namespace Test
{
   
        

  public class Test2 
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public Test2()
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



