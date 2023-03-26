using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Product
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ProductCreateParam ProductCreateParam { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var product = _mapper.Map<Domain.Product>(request.ProductCreateParam);

                _context.Products.Add(product);

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Result<Unit>.Success(new Unit());
                return Result<Unit>.Failure("Product addition failed");
            }
        }
    }
}
