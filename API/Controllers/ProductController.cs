using API.Controllers;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await Mediator.Send(new List.Query());
        }
    }

}

