using FurnitureStore.API.DTOs.OrderDetailDTOs;

namespace FurnitureStore.API.DTOs.OrderDTOs
{
    public class OrderToCreateDto
    {
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
        
    }
}
