using AutoMapper;
using GeekShoppin.ProductAPI.Data.ValueObjects;
using GeekShoppin.ProductAPI.Model;

namespace GeekShoppin.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });

            return mappingConfig;
        }
    }
}
