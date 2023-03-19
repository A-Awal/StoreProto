using Api.Controllers;
using Application.Template;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TemplateController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetTemplate(string CategoryName)
        {
            return HandleResult(await Mediator.Send(new Application.Template.GetATemplate.Query{ Category = CategoryName}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemplate(TemplateCreateParam templateCreateParam)
        {
            return HandleResult(await Mediator.Send(new Application.Template.Create.Command { TemplateCreateParam = templateCreateParam}));
        }

    }
}
