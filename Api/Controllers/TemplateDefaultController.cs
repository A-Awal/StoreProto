using Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TemplateDefaultController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetDefaultTemplate(string CategoryName)
        {
            return HandleResult(await Mediator.Send(new Application.TemplateDefault.GetATemplate.Query { Category = CategoryName}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemplate(Application.TemplateDefault.TemplateDefaultParam templateDefaultParam)
        {
            return HandleResult(await Mediator.Send(new Application.TemplateDefault.Create.Command { Param = templateDefaultParam}));
        }

    }
}
