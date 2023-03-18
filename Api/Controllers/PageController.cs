using Api.Controllers;
using Application.TemplateDefault;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PageController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetTemplate([FromBody]GetTemplateParam param)
        {
            return HandleResult(await Mediator.Send(new Application.Template.GetTemplates.Query{ Param = param }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemplate(Application.Template.TemplateDto templateDto)
        {
            return HandleResult(await Mediator.Send(new Application.Template.Create.Command { TemplateDto = templateDto}));
        }
    }
}
