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

        [HttpGet("Search")]
        public async Task<IActionResult> GetProduct(
            Guid storeId,
            string productCategory,
            string productName
        )
        {
            return HandleResult(
                await _mediator.Send(
                    new Products.Query
                    {
                        StoreId = storeId,
                        ProductCategory = productCategory,
                        ProductName = productName
                    }
                )
            );
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(ProductCreateParam product)
        {
            return HandleResult(
                await _mediator.Send(new Create.Command { ProductCreateParam = product })
            );
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateParam productUpdateParam)
        {
            return HandleResult(
                await _mediator.Send(new Update.Command { ProductUpdateParam = productUpdateParam })
            );
        }

        [HttpPost("AddPhoto")]
        public async Task<IActionResult> UpdateProduct(IFormFile productPhoto, Guid productId)
        {
            return HandleResult(
                await _mediator.Send(
                    new AddPhoto.Command { ProductPhoto = productPhoto, ProductId = productId }
                )
            );
        }
    }
}
