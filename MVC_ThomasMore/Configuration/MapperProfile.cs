using AutoMapper;
using MVC_ThomasMore.Data.Entities;
using MVC_ThomasMore.DTO.Product;
using MVC_ThomasMore.Model;

namespace MVC_ThomasMore.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductEntity, Product>()
                .ForMember(dest => dest.ProductNaam, x => x.MapFrom(src => src.Naam))
                .ReverseMap();

            CreateMap<AddProductDTO, Product>();
        }
    }
}
