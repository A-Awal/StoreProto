using Application.Core;
using Application.TemplateDefault;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Template
{
    public class GetTemplates
    {
        public class Query : IRequest<Result<TemplateDto>>
        {
            public GetTemplateParam Param { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<TemplateDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<TemplateDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var defaultTemplate = _context.Templates
                    .Where(t => t.StoreId == request.Param.StoreId)
                    .AsQueryable();
                if(request.Param.TemplateId != Guid.Empty)
                {
                    defaultTemplate = defaultTemplate.Where( d => d.TemplateId == request.Param.TemplateId);
                }

                if (defaultTemplate == null)
                {
                    return Result<TemplateDto>.Failure("This category does not exist");
                }

                var toReturn = _mapper.Map<TemplateDto>(defaultTemplate);

                return Result<TemplateDto>.Success(toReturn);
            }
        }
    }
}
