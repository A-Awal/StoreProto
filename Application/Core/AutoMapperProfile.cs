using Application.Order;
using Application.Page;
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
            CreateMap<Domain.Product, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));

            CreateMap<Domain.Purchase, PurchaseDto>();
            CreateMap<PurchaseDto, Domain.Purchase>();

            CreateMap<Domain.Purchase, OrderDto>();

            CreateMap<Domain.Store, StoreDto>();
            CreateMap<Domain.Store, StoreDto>();

            CreateMap<CreateShipingParam, Domain.ShipingDetails>();

            CreateMap<Domain.Order, CartDto>()
                .ForMember(c => c.Purchases, opt => opt.MapFrom(o => o.Purchases.Select(p => new PurchaseDto())));

            CreateMap<Domain.CreditCardDetail, CustomerResource>();

            CreateMap<Domain.Template, TemplateDto>();
            CreateMap<TemplateCreateParam, Domain.Template>();

            CreateMap<Domain.Page, PageDto>();
            CreateMap<PageDto, Domain.Page>();
        }

    }
}
