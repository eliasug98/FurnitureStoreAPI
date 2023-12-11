using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FurnitureStore.API.Entities
{
    public class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Icon { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }

        //public ProductCategory(int id, string name, string description, ICollection<Product> products)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    Products = products;
        //}
    }
}
