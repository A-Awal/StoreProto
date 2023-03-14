using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Order
{
    public class Create
    {
        public class Command : IRequest<Result<String>>
        {
            public OrderDto orderDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<String>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result< String>> Handle(Command request, CancellationToken cancellationToken)
            {
                var productToOrder = await _context.Products.FindAsync(request.orderDto.ProductId);
                if(productToOrder== null || productToOrder.Quantity <= 0 )
                {
                    return Result<String>.Failure("Please we are out of stock");
                }

                try{
                    var order = _mapper.Map<Domain.Order>(request.orderDto);
                    _context.Orders.Add(order);
                    var success = await _context.SaveChangesAsync() > 0;
                    if(success) return Result<String>.Success("Order made successfully");
                    return Result<String>.Failure("Sorry try ordering again"); 
                } catch(Exception)
                {
                    return Result<String>.Failure("Please we are out of stock");
                }



            }
        }


    }
}