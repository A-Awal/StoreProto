using Application.Core;
using Application.Store;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Template
{
    public class Create
    {
        public class Command : IRequest<Result<TemplateDto>>
        {
            public StoreDto storeDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<TemplateDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<TemplateDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var store = _context.Templates.Find(request.storeDto.StoreId);

                if (store == null) return Result<TemplateDto>.Failure("store does not exist");

                Domain.Template newTem = new Domain.Template
                {
                    StoreId = request.storeDto.StoreId
                };

                _context.Templates.Add(newTem);
                await _context.SaveChangesAsync();

                var newstore = _mapper.Map<TemplateDto>(newTem);

                return Result<TemplateDto>.Success(newstore);

            }
        }
    }
}
