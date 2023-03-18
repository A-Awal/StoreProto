using Application.Core;
using Application.Template;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Store
{
    public class Create
    {
        public class Command: IRequest<Result<StoreDto>>
        {
            public CreateStoreParam CreateStoreParam { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<StoreDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<StoreDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                
                try
                {
                    Domain.Store newTem = new()
                    {
                        MerchantId = request.CreateStoreParam.MerchantId,
                        StoreName = request.CreateStoreParam.storeName
                    };

                    _context.Stores.Add(newTem);
                    await _context.SaveChangesAsync(cancellationToken);

                    var newstore = _mapper.Map<StoreDto>(newTem);

                    return Result<StoreDto>.Success(newstore);

                } catch(Exception ex)
                {
                    return Result<StoreDto>.Failure(ex.Message);
                }

            }
        }
    }
}
