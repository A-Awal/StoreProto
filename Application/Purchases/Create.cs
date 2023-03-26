using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Purchases
{
	public class Create
    {
        public class Command : IRequest<Result<PurchaseDto>>
        {
            public PurchaseCreateParam PurchaseCreateParam { get; set; }
            public Guid OrderId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<PurchaseDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<PurchaseDto>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var productToOrder = await _context.Products.FindAsync(
                    request.PurchaseCreateParam.ProductId
                );

                if (productToOrder == null || productToOrder.Quantity < request.PurchaseCreateParam.QuantityPurchased)
                {
                    return Result<PurchaseDto>.Failure("Please we are out of stock");
                }

                try
                {
                    var orderToUpdate = _context.Orders.Find(request.OrderId);

                    if (orderToUpdate == null)
                        return Result<PurchaseDto>.Failure("Cart does not exist");

                    orderToUpdate.TotalAmount =
                        orderToUpdate.TotalAmount
                        + productToOrder.UnitPrice * request.PurchaseCreateParam.QuantityPurchased;
                    _context.Orders.Update(orderToUpdate);

                    var newpurchase = _mapper.Map<Domain.Purchase>(request.PurchaseCreateParam);

                    newpurchase.OrderId = request.OrderId;

                    _context.Add(newpurchase);
                    var success = await _context.SaveChangesAsync() > 0;

                    var purchaseDto = _mapper.Map<PurchaseDto>(newpurchase);

                    if (success)
                        return Result<PurchaseDto>.Success(purchaseDto);

                    return Result<PurchaseDto>.Failure("Purchase failed");
                }
                catch (Exception ex)
                {
                    return Result<PurchaseDto>.Failure(ex.Message);
                }
            }
        }
    }
}
