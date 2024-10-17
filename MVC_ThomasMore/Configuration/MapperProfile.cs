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

            CreateMap<Product, ProductDTO>()
                .ForMember(x => x.Categorie, y => y.MapFrom(z => z.Categorie.Name ?? "Onbekend"));

            CreateMap<CategorieEntity, Categorie>()
                .ReverseMap();

            CreateMap<AddProductDTO, Product>();

            //CreateMap<RegistratieDTO, CustomUser>();
        }
    }
}
