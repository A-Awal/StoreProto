using Application.Core;
using Application.Purchase;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Persistence;

namespace Application.Order
{
    public class Create
    {
        public class Command:IRequest<Result<Guid>> {
            public PurchaseDto purchaseDto { get; set; }
        }
        
        public class Handler:IRequestHandler<Command, Result<Guid>>
        {
            private readonly AppDataContext _context;

            public Handler(AppDataContext context)
            {
                _context = context;

            }

            public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
            {
                var existingOrder = _context.Orders.FirstOrDefault( o => o.CustomerId == request.purchaseDto.CustomerId && o.OrderState == Domain.OrderStates.cart);
                    
                if(existingOrder == null)
                {
                    var newOrder = new Domain.Order
                    {
                        CustomerId = request.purchaseDto.CustomerId,
                        OrderState = Domain.OrderStates.cart,

                    };

                    _context.Orders.Add(newOrder);

                    await _context.SaveChangesAsync();

                    Guid id = _context.Orders.FirstOrDefault( o => o.CustomerId == request.purchaseDto.CustomerId && o.OrderState == Domain.OrderStates.cart).OrderId;
                    return Result<Guid>.Success(id);
                } else {

                    return Result<Guid>.Success(existingOrder.OrderId);
                }

            }
        }
    }
}