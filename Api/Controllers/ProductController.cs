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
        public async Task<IActionResult> GetProduct(string productName)
        {
            return HandleResult(await _mediator.Send(new Products.Query { ProductName = productName }));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(ProductCreateParam product)
        {
            return HandleResult(await _mediator.Send(new Create.Command { ProductCreateParam = product }));
        }

        [HttpGet("Quantity")]
        public async Task<IActionResult> Available(Guid productId)
        {
            return HandleResult(await _mediator.Send(new Availability.Query { ProductId = productId }));
        }
    }
}
