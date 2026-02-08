using AutoMapper;
using Talabat.Dto;
using TalabatCore.Entites;

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
        }
    }
}
