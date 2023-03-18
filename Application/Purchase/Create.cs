using Application.Core;
using Application.Purchase;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Purchase
{
    public class Create
    {
        public class Command : IRequest<Result<string>>
        {
            public PurchaseDto purchaseDto { get; set; }
            public Guid cartId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<string>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<string>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var productToOrder = await _context.Products.FindAsync(
                    request.purchaseDto.ProductId
                );

                if (productToOrder == null || productToOrder.Quantity <= 0)
                {
                    return Result<string>.Failure("Please we are out of stock");
                }

                try
                {
                    
                    var orderToUpdate = _context.Orders.Find(request.cartId);
                    orderToUpdate.TotalAmount = orderToUpdate.TotalAmount + productToOrder.UnitPrice * request.purchaseDto.QuantityPurchase;
                    _context.Orders.Update(orderToUpdate);

                    var newpurchase = _mapper.Map<Domain.Purchase>(request.purchaseDto);
                    newpurchase.OrderId = orderToUpdate.OrderId;

                    var success = await _context.SaveChangesAsync() > 0;

                    if (success) return Result<string>.Success("Order made successfully");
                }
                catch (Exception ex)
                {
                    return Result<string>.Failure(ex.Message);
                }

                return Result<string>.Failure("Purchase Failed");
            }
        }
    }
}
