using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Template
{
    public class GetATemplate
    {
        public class Query: IRequest<Result<TemplateDto>>
        {
            public string Category { get; set; }
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
                var defaultTemplate = await _context.Templates.Include(t => t.TemplatePhotos).FirstOrDefaultAsync(t => t.TemplateCategory.Contains(request.Category));
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
