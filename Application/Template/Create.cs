using Application.Core;
using Application.Interfaces;
using Application.Page;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Template
{
    public class Create
    {
        public class Command : IRequest<Result<TemplateDto>>
        {
            public TemplateCreateParam TemplateCreateParam { get; set; }
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

            public async Task<Result<TemplateDto>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                try
                {
                    var newTemplate = _mapper.Map<Domain.Template>(request.TemplateCreateParam);
                    newTemplate.HeroImage = "";
                    newTemplate.Logo = "";
                    newTemplate.MainHeaderTextSize = "";
                    newTemplate.SubHeaderTextsize = "";

                    _context.Templates.Add(newTemplate);
                    await _context.SaveChangesAsync();

                    var template = _context.Templates.First(
                        t => t.TemplateNumber == newTemplate.TemplateNumber
                    );

                    var templateToReturn = _mapper.Map<TemplateDto>(template);

                    return Result<TemplateDto>.Success(templateToReturn);
                }
                catch (Exception ex)
                {
                    return Result<TemplateDto>.Failure(ex.Message);
                }
            }
        }
    }
}
