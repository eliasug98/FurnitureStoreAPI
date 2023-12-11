using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FurnitureStore.API.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [JsonIgnore]
        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public decimal Total
        {
            get
            {
                return OrderDetails.Sum(od => od.Price * od.Quantity);
            }
        }
    }

    //public Order(int id, DateTime orderDate, int userId, User user, ICollection<OrderDetail> orderDetails)
    //{
    //    Id = id;
    //    OrderDate = orderDate;
    //    UserId = userId;
    //    this.user = user;
    //    OrderDetails = orderDetails;
    //}
}

