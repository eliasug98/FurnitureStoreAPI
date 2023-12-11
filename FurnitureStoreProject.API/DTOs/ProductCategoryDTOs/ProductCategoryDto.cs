using FurnitureStore.API.DTOs.ProductDTOs;
using FurnitureStore.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace FurnitureStore.API.DTOs.ProductCategoryDTOs
{
    public class ProductCategoryDto
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
