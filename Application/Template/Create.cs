using Application.Core;
using Application.Services;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Template
{
    public class Create
    {
        public class Command : IRequest<Result<Guid>>
        {
            public TemplateCreateParam TemplateCreateParam { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Guid>>
        {
            private readonly AppDataContext _context;
            private readonly IMapper _mapper;
            private readonly IPhotoAccessor _photoAccessor;

            public Handler(AppDataContext context, IMapper mapper, IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Guid>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                try
                {
                    Domain.Template newTem = new Domain.Template
                    {
                        TemplateCategory = request.TemplateCreateParam.TemplateCategory,
                        MainHearderTextSize  = request.TemplateCreateParam.MainHearderTextSize,
                        SubHearderTextsize = request.TemplateCreateParam.SubHearderTextsize,
                        HeroMainHearderText = request.TemplateCreateParam.HeroMainHearderText,
                        HeroMainSubHearderText = request.TemplateCreateParam.HeroMainSubHearderText,
                        FooterTextHearder = request.TemplateCreateParam.FooterTextHearder,
                        SocialMedia = request.TemplateCreateParam.SocialMedia,
                    };

                    _context.Templates.Add(newTem);
                    await _context.SaveChangesAsync();

                    var tem = _context.Templates.First(t => t.TemplateCategory == newTem.TemplateCategory).TemplateId;

                    return Result<Guid>.Success(tem);
                }
                catch (Exception ex)
                {
                    return Result<Guid>.Failure(ex.Message);
                }
            }
        }
    }
}