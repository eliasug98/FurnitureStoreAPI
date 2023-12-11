using AutoMapper;

namespace FurnitureStore.API.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, DTOs.ProductDTOs.ProductDto>();
            CreateMap<DTOs.ProductDTOs.ProductDto, Entities.Product>();
            CreateMap<DTOs.ProductDTOs.ProductToCreateDto, Entities.Product>();
            CreateMap<DTOs.ProductDTOs.ProductToUpdateDto, Entities.Product>();
        }
    }
}
