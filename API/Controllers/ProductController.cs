using API.Controllers;
using Application;
using Application.Helpers;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery]  ParamsPagination param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query(){pageParmams = param}));
        }


        [HttpPost]
        public async Task<ActionResult<bool>> AddProducts([FromBody] Product product)//productDTO
        {
            return HandleResult(await Mediator.Send(new Add.Command(){Product = product}));
        }


    }

}

