using Application.Template;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class TemplateController : BaseApiController
    {
        [HttpGet("Search")]
        public async Task<IActionResult> GetTemplate(string CategoryName)
        {
            return HandleResult(
                await Mediator.Send(
                    new Application.Template.GetTemplate.Query { Category = CategoryName }
                )
            );
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTemplate(TemplateUpdateParam templateUpdateParam)
        {
            return HandleResult(
                await Mediator.Send(
                    new Application.Template.Update.Command
                    {
                        TemplateUpdateParam = templateUpdateParam
                    }
                )
            );
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTemplate(TemplateCreateParam templateCreateParam)
        {
            return HandleResult(
                await Mediator.Send(
                    new Application.Template.Create.Command
                    {
                        TemplateCreateParam = templateCreateParam
                    }
                )
            );
        }

        [HttpPost("AddHeroPhoto")]
        public async Task<IActionResult> AddHeroPhoto(IFormFile heroPhoto, Guid templateId)
        {
            return HandleResult(
                await Mediator.Send(
                    new Application.Template.AddHeroPhoto.Command
                    {
                        HeroPhoto = heroPhoto,
                        TemplateId = templateId
                    }
                )
            );
        }

        [HttpPost("AddLogoPhoto")]
        public async Task<IActionResult> AddlogoPhoto(IFormFile logoPhoto, Guid templateId)
        {
            return HandleResult(
                await Mediator.Send(
                    new Application.Template.AddLogoPhoto.Command
                    {
                        LogoPhoto = logoPhoto,
                        TemplateId = templateId
                    }
                )
            );
        }
    }
}
