using Api.Controllers;
using Application.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(string searchTerm)
        {
            return HandleResult(await _mediator.Send(new Products.Query { SearchTerm = searchTerm }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto product)
        {
            return Ok(await _mediator.Send(new Create.Command { ProductDto = product }));
        }
    }
}
