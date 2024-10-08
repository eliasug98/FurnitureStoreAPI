using FurnitureStore.API.DTOs.ProductDTOs;

namespace FurnitureStore.API.DTOs.ProductCategoryDTOs
{
    public class ProductCategoryToUpdateDto
    {
        public string CurrentName { get; set; }
        public string Icon { get; set; }
        public string NewName { get; set; }
        public string Description { get; set; }
    }
}
