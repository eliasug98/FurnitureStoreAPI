namespace FurnitureStore.API.DTOs.ProductDTOs
{
    public class ProductToUpdateDto
    {
        public string Image { get; set; }

        public bool Available { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

    }
}
