using FluentValidation;

namespace Application.Product
{
    public class ProductValidator: AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.ProductDescription).NotEmpty();
            RuleFor(x => x.ProductCategory).NotEmpty();
            RuleFor(x => x.Unit).NotNull();
            RuleFor(x => x.Quantity).NotEmpty();
        }
    }
}
