using Api.Controllers;
using Application.Photos;
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

        [HttpPost("Add-hero-photo")]
        public async Task<IActionResult> AddHeroPhoto(IFormFile heroPhoto,  Guid templateId)
        {
            return HandleResult(await Mediator.Send(new Application.Template.AddHeroPhoto.Command{ HeroPhoto = heroPhoto, TemplateId = templateId}));
        }
        [HttpPost("Add-logo-photo")]
        public async Task<IActionResult> AddlogoPhoto(IFormFile logoPhoto,  Guid templateId)
        {
            return HandleResult(await Mediator.Send(new Application.Template.AddLogoPhoto.Command{LogoPhoto = logoPhoto, TemplateId = templateId}));
        }

    }
}
