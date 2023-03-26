using Application.Orders;
using Application.Page;
using Application.Photos;
using Application.Product;
using Application.Purchases;
using Application.Shipping;
using Application.Store;
using Application.Stripe;
using Application.Template;
using AutoMapper;
using Domain;

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
                .ForMember(pd => pd.StoreName, opt => opt.MapFrom(p => p.Store.StoreName));
            
            CreateMap<Domain.Store, StoreDto>();
            CreateMap<Domain.Store, StoreDto>();

            CreateMap<Domain.Template, TemplateDto>()
                .ForMember(td => td.HeroImage, opt => 
                    opt.MapFrom(t => t.TemplatePhotos.Any()? t.TemplatePhotos.First(tp => tp.Id == t.HeroImage).Url:""))
                    
                .ForMember(td => td.Logo, opt => 
                    opt.MapFrom(t => t.TemplatePhotos.Any()? t.TemplatePhotos.First(tp => tp.Id == t.Logo).Url:""));
                
            CreateMap<TemplateDto, Domain.Template>();
            CreateMap<TemplateUpdateParam, Domain.Template>();
            
            CreateMap<TemplateCreateParam, Domain.Template>();

            CreateMap<Domain.TemplatePhoto, PhotoUploadResult>()
                .ForMember(p => p.PublicId, opt => opt.MapFrom(t => t.Id));

            CreateMap<Domain.Page, PageDto>()
                .ForMember(td => td.HeroImage, opt => 
                    opt.MapFrom(t => t.PagePhotos.Any()? t.PagePhotos.First(tp => tp.Id == t.HeroImage).Url:""))

                .ForMember(td => td.StoreName, opt => 
                    opt.MapFrom(t => t.Store.StoreName))

                .ForMember(td => td.Logo, opt => 
                    opt.MapFrom(t => t.PagePhotos.Any()? t.PagePhotos.First(tp => tp.Id == t.Logo).Url:""));

            CreateMap<CreatePageParam, Domain.Page>();

            CreateMap<Domain.Purchase, PurchaseCreateParam>();
            CreateMap<PurchaseCreateParam, Domain.Purchase>();
            CreateMap<Domain.Purchase, PurchaseDto>()
                .ForMember(pd => pd.Product, opt => opt.MapFrom(p => p.Product.ProductName))
                .ForMember(pd => pd.Order, opt => opt.MapFrom(p => p.Order.OrderId));

            CreateMap<Domain.Order, OrderDto>()
                .ForMember(od => od.Purchases, opt => opt.MapFrom(o => o.Purchases.Select(p => new {p.PurchaseState, p.DatePurchased, p.QuantityPurchased})))
                .ForMember(od => od.Customer, opt => opt.MapFrom(o => o.Customer.FirstName));

            CreateMap<CreateCustomerParam, CreditCardDetail>()
                .ForMember(cc => cc.ExpiryMonth, opt => opt.MapFrom(c => c.Card.Cvc))
                .ForMember(cc => cc.ExpiryMonth, opt => opt.MapFrom(c => c.Card.Cvc))
                .ForMember(cc => cc.ExpiryMonth, opt => opt.MapFrom(c => c.Card.Cvc));
            CreateMap<ShippingDetails, ShippingParam>();
            CreateMap<ShippingParam, ShippingDetails>();
            CreateMap<ShippingDetails, ShippingDto>();
            

        }   

       
    }
}
