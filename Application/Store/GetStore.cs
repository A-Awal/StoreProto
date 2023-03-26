using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Store
{
    public class GetStore
    {
        public class Query : IRequest<Result<StoreDto>>
        {
            public Guid StoreId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<StoreDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<StoreDto>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var store = await _context.Stores.FindAsync(request.StoreId);

                if (store == null)
                {
                    var storeDto = _mapper.Map<StoreDto>(store);
                    return Result<StoreDto>.Success(storeDto);
                }

                return Result<StoreDto>.Failure("Store does not exist");
            }
        }
    }
}
