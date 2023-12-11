﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FurnitureStore.API.Entities
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonIgnore]
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Required]
        public int OrderId { get; set; }

        [JsonIgnore]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        //public OrderDetail(int id, Order order, int orderId, int productId, int quantity, decimal price)
        //{
        //    Id = id;
        //    Order = order;
        //    OrderId = orderId;
        //    ProductId = productId;
        //    Quantity = quantity;
        //    Price = price;
        //}
    }
}
