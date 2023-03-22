using Application.Order;
using Application.Page;
using Application.Photos;
using Application.Product;
using Application.Purchase;
using Application.Shiping;
using Application.Store;
using Application.Stripe.Resources;
using Application.Template;
using AutoMapper;

namespace Application.Core
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDto, Domain.Product>();
            CreateMap<Domain.Product, ProductCreateParam>();
            CreateMap<ProductCreateParam, Domain.Product>();
            CreateMap<Domain.Product, ProductDto>()
            .ForMember(d => d.Store, opt => opt.MapFrom(p => p.Store.StoreName));

            CreateMap<Domain.Purchase, PurchaseDto>();
            CreateMap<PurchaseDto, Domain.Purchase>();

            CreateMap<Domain.Purchase, OrderDto>();

            CreateMap<Domain.Store, StoreDto>();
            CreateMap<Domain.Store, StoreDto>();

            CreateMap<CreateShipingParam, Domain.ShipingDetails>();

            CreateMap<Domain.Order, CartDto>()
                .ForMember(c => c.Purchases, opt => opt.MapFrom(o => o.Purchases.Select(p => new PurchaseDto())));

            CreateMap<Domain.CreditCardDetail, CustomerResource>();

            CreateMap<Domain.Template, TemplateDto>()
                .ForMember(td => td.HeroImage, opt => opt.MapFrom(t => t.TemplatePhotos.Any()? t.TemplatePhotos.First(tp => tp.Id == t.HeroImage).Url:""))
                .ForMember(td => td.Logo, opt => opt.MapFrom(t => t.TemplatePhotos.Any()? t.TemplatePhotos.First(tp => tp.Id == t.Logo).Url:""));
            CreateMap<TemplateCreateParam, Domain.Template>();

            CreateMap<Domain.TemplatePhoto, PhotoUploadResult>()
                .ForMember(p => p.PublicId, opt => opt.MapFrom(t => t.Id));

            CreateMap<Domain.Page, PageDto>();
            CreateMap<PageDto, Domain.Page>();
        }

    }
}
