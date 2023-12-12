using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FurnitureStore.API.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public bool Available { get; set; } = true;

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [JsonIgnore]
        [ForeignKey("CategoryId")]
        public ProductCategory Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        //public Product(int id, string name, string description, decimal price, ProductCategory category, int categoryId)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    Price = price;
        //    Category = category;
        //    CategoryId = categoryId;
        //}
    }
}
