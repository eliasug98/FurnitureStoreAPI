using FurnitureStore.API.DTOs.OrderDetailDTOs;

namespace FurnitureStore.API.DTOs.OrderDTOs
{
    public class OrderToCreateDto
    {
        public ICollection<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
    }
}
