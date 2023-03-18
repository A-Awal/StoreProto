using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.TemplateDefault
{
    public class GetATemplate
    {
        public class Query: IRequest<Result<TemplateDefaultDto>>
        {
            public string Category { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<TemplateDefaultDto>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<TemplateDefaultDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var defaultTemplate = await _context.TemplateDefaults.FirstOrDefaultAsync(t => t.TemplateCategory.Contains(request.Category));
                if (defaultTemplate == null)
                {
                    return Result<TemplateDefaultDto>.Failure("This category does not exist");
                }

                var toReturn = _mapper.Map<TemplateDefaultDto>(defaultTemplate);
                return Result<TemplateDefaultDto>.Success(toReturn);
            }
        }
    }
}
