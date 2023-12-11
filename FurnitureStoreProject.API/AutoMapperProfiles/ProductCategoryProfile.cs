using AutoMapper;

namespace FurnitureStore.API.AutoMapperProfiles
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<Entities.ProductCategory, DTOs.ProductCategoryDTOs.ProductCategoryDto>();
            CreateMap<DTOs.ProductCategoryDTOs.ProductCategoryDto, Entities.ProductCategory > ();
            CreateMap<DTOs.ProductCategoryDTOs.ProductCategoryToCreateDto, Entities.ProductCategory>();
            CreateMap<DTOs.ProductCategoryDTOs.ProductCategoryToUpdateDto, Entities.ProductCategory>();
        }
        
    }
}
