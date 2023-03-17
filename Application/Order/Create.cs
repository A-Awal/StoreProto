using Application.Purchase;
using MediatR;
using Persistence;

namespace Application.Order
{
    public class Create
    {
        public class Query:IRequest<Guid> {
            public PurchaseDto purchaseDto { get; set; }
        }
        
        public class Handler:IRequestHandler<Query, Guid>
        {
            private readonly AppDataContext _context;

            public Handler(AppDataContext context)
            {
                _context = context;

            }

            public async Task<Guid> Handle(Query request, CancellationToken cancellationToken)
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
                    return id;
                } else {
                    return existingOrder.OrderId;
                }


                

            }
        }
    }
}