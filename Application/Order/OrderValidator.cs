using FluentValidation;

namespace Application.Order
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {
            RuleFor( o => o.ProductId).NotEmpty();
            RuleFor( o => o.QuantityOrdered).NotNull();
        }
    }
}