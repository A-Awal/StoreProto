using Application.Core;
using MediatR;
using Persistence;

namespace Application.Product
{
    public class Availability
    {
        public class Query:IRequest<Result<int>>
        {
            public Guid ProductId { get; set; }
        }

        public class Hanler : IRequestHandler<Query, Result<int>>
        {
            private readonly AppDataContext _context;

            public Hanler(AppDataContext context)
            {
                _context = context;
            }

            public async Task<Result<int>> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.ProductId);
                var quatity = product.Quantity;

                return quatity >= 0 ? Result<int>.Success(quatity) : Result<int>.Success(0);
            }
        }
    }
}
