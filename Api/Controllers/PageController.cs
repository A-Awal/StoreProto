using Api.Controllers;
using Application.Page;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PageController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetPage([FromBody]GetPageParam getPageParam)
        {
            return HandleResult(await Mediator.Send(new Application.Page.GetPages.Query{GetPageParam = getPageParam}));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePage(PageDto pageDto)
        {
            return HandleResult(await Mediator.Send(new Application.Page.Create.Command{PageDto = pageDto}));
        }
    }
}
