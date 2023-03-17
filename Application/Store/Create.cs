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
            public TemplateParam templateParam { get; set; }
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
                var store = _context.Templates.Find(request.templateParam.StoreId);

                if (store != null)
                {
                    var existingStore = _mapper.Map<StoreDto>(store);

                    return Result<StoreDto>.Success(existingStore);
                }

                Domain.Store newTem = new Domain.Store
                {
                    StoreId = request.templateParam.StoreId,
                    MerchantId = request.templateParam.MerchantId
                };

                _context.Stores.Add(newTem);
                await _context.SaveChangesAsync();

                var newstore = _mapper.Map<StoreDto>(newTem);

                return Result<StoreDto>.Success(newstore);

            }
        }
    }
}
