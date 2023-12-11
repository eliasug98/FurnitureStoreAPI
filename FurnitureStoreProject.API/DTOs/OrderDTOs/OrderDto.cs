using FurnitureStore.API.DTOs.OrderDetailDTOs;
using FurnitureStore.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace FurnitureStore.API.DTOs.OrderDTOs
{
    public class OrderDto
    {
        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

        public IList<OrderDetailDto> OrderDetails { get; set; }

    }
}
