using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product
{
    public class Availability
    {
        public class Query:IRequest<int>
        {
            public Guid productId { get; set; }
        }

        public class Hanler : IRequestHandler<Query, int>
        {
            private readonly AppDataContext _context;

            public Hanler(AppDataContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.productId);
                var quatity = product.Quantity;

                return quatity >= 0 ? quatity : 0;
            }
        }
    }
}
