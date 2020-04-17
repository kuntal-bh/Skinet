using API.DTOs;
using AutoMapper;
using core.Entities;

namespace API.Helpers
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<Product,ProductToReturnDTO>()
            .ForMember(des=>des.ProductBrand, op=>op.MapFrom(s=>s.ProductBrand.Name))
            .ForMember(des=>des.ProductType, op=>op.MapFrom(s=>s.ProductType.Name))
            .ForMember(des=>des.PictureUrl, op=>op.MapFrom<ProductValueResolver>());
        }

 
    }
}