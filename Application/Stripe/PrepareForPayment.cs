using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Stripe
{
    public class PrepareForPayment
    {
        public class Command : IRequest<Result<decimal>>
        {
            public Guid CustomerId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<decimal>>
        {
            private readonly AppDataContext _context;

            public Handler(AppDataContext context)
            {
                _context = context;
            }

            public async Task<Result<decimal>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var order = _context.Orders
                    .Include(o => o.Purchases)
                    .FirstOrDefault(
                        o =>
                            o.CustomerId == request.CustomerId
                            && o.OrderState == Domain.OrderStates.processing
                    );

                if (order == null)
                    return Result<decimal>.Failure("Customer has no cart");
                try
                {
                    foreach (Domain.Purchase purchase in order.Purchases)
                    {
                        var product = _context.Products.Find(purchase.ProductId);
                        product.Quantity = product.Quantity - purchase.QuantityPurchased;
                        purchase.PurchaseState = Domain.PurchaseState.purchased;
                        _context.Products.Update(product);
                    }

                    order.OrderState = Domain.OrderStates.shipping;
                    var success = await _context.SaveChangesAsync() > 0;

                    if (!success)
                        return Result<decimal>.Failure("Failed to process order");

                    return Result<decimal>.Success(order.TotalAmount);
                }
                catch (Exception ex)
                {
                    return Result<decimal>.Failure(ex.Message);
                }
            }
        }
    }
}
