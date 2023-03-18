using Api.Controllers;
using Application.Store;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StoreController : BaseApiController
    {
        [HttpPost("Create-A-New-Store")]
        public async Task<IActionResult> CreateStore(CreateStoreParam param)
        {    
           return HandleResult( await Mediator.Send(new Application.Store.Create.Command { CreateStoreParam = param }));
        }


    }
    
}
