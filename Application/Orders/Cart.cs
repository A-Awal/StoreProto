using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Orders
{
    public class Cart
    {
        public class Query : IRequest<Result<OrderDto>>
        {
            public Guid CustomerId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<OrderDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<OrderDto>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var customer = _context.Customers.Any(c => c.Id == request.CustomerId);
                if (!customer)
                    return Result<OrderDto>.Failure("Customer does not exist");

                var cartt = await _context.Orders
                    .Include(o => o.Purchases)
                    .AsNoTracking()
                    .Include(o => o.Customer)
                    .Where(
                        o =>
                            o.CustomerId == request.CustomerId
                            && o.OrderState == Domain.OrderStates.processing
                    )
                    .FirstOrDefaultAsync();

                var cart = _mapper.Map<OrderDto>(cartt);

                if (cart == null)
                    return Result<OrderDto>.Failure("Customer does not exist");

                return Result<OrderDto>.Success(cart);
            }
        }
    }
}
