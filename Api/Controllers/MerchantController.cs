using Api.Controllers;
using Application.Template;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MerchantController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateStore ( TemplateParam param)
        {
            var newOrExistingStore = await Mediator.Send(new Application.Store.Create.Command { templateParam = param });

            if(newOrExistingStore.IsSuccess) {
                try
                {
                    var newStore = await Mediator.Send(new Application.Template.Create.Command { storeDto = newOrExistingStore.Value });
                    if (newStore.IsSuccess)
                    {
                        return Ok(newStore.Value);
                    }

                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }

            }

            return Problem();
            
        }
    }
}
 