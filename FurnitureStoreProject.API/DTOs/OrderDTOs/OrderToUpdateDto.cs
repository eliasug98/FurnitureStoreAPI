using FurnitureStore.API.DTOs.OrderDetailDTOs;

namespace FurnitureStore.API.DTOs.OrderDTOs
{
    public class OrderToUpdateDto
    {
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public IList<OrderDetailDto> OrderDetails { get; set; }
    }
}
