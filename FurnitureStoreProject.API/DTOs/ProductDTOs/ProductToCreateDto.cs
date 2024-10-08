namespace FurnitureStore.API.DTOs.ProductDTOs
{
    public class ProductToCreateDto
    {
        public string Image { get; set; }

        public bool Available { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
