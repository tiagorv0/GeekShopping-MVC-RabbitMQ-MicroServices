using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Model;

namespace GeekShopping.CartAPI.Config
{
    public class MappingConfig : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>().ReverseMap();
                config.CreateMap<CartDetail, CartDetailVO>().ReverseMap();
                config.CreateMap<CartHeader, CartHeaderVO>().ReverseMap();
                config.CreateMap<Cart, CartVO>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
