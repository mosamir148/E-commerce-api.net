using AutoMapper;
using Talabat.Dto;
using TalabatCore.Entites;
using TalabatCore.Entites.Order_Agreggate;

namespace Talabat.Helpres
{
    public class MppingProfile:Profile
    {
        public MppingProfile()
        {
            CreateMap<Product, productToDtos>()
                .ForMember(o => o.ProductBrand, o => o.MapFrom(e => e.ProductBrand.Name))
                .ForMember(o => o.ProductType, o => o.MapFrom(e => e.ProductType.Name))
                .ForMember(o => o.PictureUrl, o => o.MapFrom<Pictureurlresolver>());
            CreateMap<TalabatCore.Entites.Address, AdressDto>().ReverseMap();
            CreateMap<CustomerItemDto, CustomerBasket>();
            CreateMap<BasKetItemDto, BasketItem>();
            CreateMap<AdressDto, TalabatCore.Entites.Order_Agreggate.Address>();
        }
    }
}
