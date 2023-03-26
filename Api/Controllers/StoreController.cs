using Application.Store;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class StoreController : BaseApiController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateStore(CreateStoreParam param)
        {
            return HandleResult(
                await Mediator.Send(
                    new Application.Store.Create.Command { CreateStoreParam = param }
                )
            );
        }
    }
}
