using Application.Core;
using Application.Photos;
using Application.Services;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Application.Template
{
    public class AddHeroPhoto
    {
        public class Command : IRequest<Result<PhotoUploadResult>>
        {
            public IFormFile HeroPhoto { get; set; }
            public Guid TemplateId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<PhotoUploadResult>>
        {
            private readonly AppDataContext _context;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly IMapper _mapper;

            public Handler(AppDataContext context, IPhotoAccessor photoAccessor, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
                _photoAccessor = photoAccessor;
            }

            public async Task<Result<PhotoUploadResult>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var tem = _context.Templates.Find(request.TemplateId);

                var HeroImage = await _photoAccessor.AddPhoto(request.HeroPhoto);
                tem.HeroImage = HeroImage.PublicId;

                TemplatePhoto heroPhoto = new TemplatePhoto
                {
                    Id = HeroImage.PublicId,
                    Url = HeroImage.Url,
                    TemplateId = tem.TemplateId
                };

                _context.TemplatePhotos.Add(heroPhoto);

                await _context.SaveChangesAsync();

                var res = _mapper.Map<PhotoUploadResult>(heroPhoto);

                return Result<PhotoUploadResult>.Success(res);
            }
        }
    }
}
