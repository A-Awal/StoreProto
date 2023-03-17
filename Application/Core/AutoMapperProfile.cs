using Application.Order;
using Application.Product;
using Application.Purchase;
using Application.Store;
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
        }

    }
}
