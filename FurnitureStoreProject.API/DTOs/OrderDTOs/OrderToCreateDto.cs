using FurnitureStore.API.DTOs.OrderDetailDTOs;

namespace FurnitureStore.API.DTOs.OrderDTOs
{
    public class OrderToCreateDto
    {
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderDetailToCreateDto> OrderDetails { get; set; } = new List<OrderDetailToCreateDto>();
        
        // probe con List, ICollection, IList, no probe modificando db de ICollection en Entidad a List
    }   // es error en orderdetaildto tengo q mapear a orderdetail, es en controller o en profile, aca paso a OrderDetailToCreateDto y en controller comento el mapeo
}
