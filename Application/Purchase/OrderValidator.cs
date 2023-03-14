using FluentValidation;

namespace Application.Purchase
{
    public class PurchaseValidator : AbstractValidator<PurchaseDto>
    {
        public PurchaseValidator()
        {
            RuleFor( o => o.ProductId).NotEmpty();
            RuleFor( o => o.QuantityPurchase).NotNull();
        }
    }
}