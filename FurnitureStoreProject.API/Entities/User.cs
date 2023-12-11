using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FurnitureStore.API.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
        //public entidad entidad { get; set; }
        //public ICollection<entidad> entidad { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public DateTime CreatedDate { get; private set; } = DateTime.Now;

    }
}
