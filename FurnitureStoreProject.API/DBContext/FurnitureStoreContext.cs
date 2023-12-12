using FurnitureStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.API.DBContext
{
    public class FurnitureStoreContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }

        public FurnitureStoreContext(DbContextOptions<FurnitureStoreContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull); //.Restrict asegura que no se pueda eliminar un producto si hay detalles de pedido relacionados con ese producto

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            
            var productCategories = new ProductCategory[3]
            {
                new ProductCategory()
                {
                    Id = 1,
                    Icon = "muebleGrande",
                    Name = "Muebles de Madera",
                    Description = "Muebles grandes de madera.",
                },
                new ProductCategory()
                {
                    Id = 2,
                    Icon = "muebleMediano",
                    Name = "Muebles medianos",
                    Description = "Muebles medianos en oferta",
                },
                new ProductCategory()
                {
                    Id = 3,
                    Icon = "mueblePequenio",
                    Name = "Muebles pequeños",
                    Description = "Muebles pequeños para decoracion",
                },
            };
            modelBuilder.Entity<ProductCategory>().HasData(productCategories);

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Image = "mesa.svg",
                    Available = true,
                    Name = "Mesa",
                    Description = "La mesa de madera.",
                    Price = 420,
                    CategoryId = productCategories[0].Id
                },
                new Product()
                {
                    Id = 2,
                    Image = "silla.svg",
                    Available = false,
                    Name = "Silla",
                    Description = "La silla de madera.",
                    Price = 320,
                    CategoryId = productCategories[0].Id
                },
                new Product()
                {
                    Id = 3,
                    Image = "sillon.svg",
                    Available = true,
                    Name = "Sillon",
                    Description = "El sillon comodo y lujoso.",
                    Price = 520,
                    CategoryId = productCategories[1].Id
                },
                new Product()
                {
                    Id = 4,
                    Image = "ropero.svg",
                    Available = false,
                    Name = "Ropero",
                    Description = "El ropero mas grande.",
                    Price = 520,
                    CategoryId = productCategories[1].Id
                },
                new Product()
                {
                    Id = 5,
                    Image = "mesita.svg",
                    Available = true,
                    Name = "Mesita pequeña",
                    Description = "Mesita pequeña con 3 patas.",
                    Price = 520,
                    CategoryId = productCategories[2].Id
                },
                new Product()
                {
                    Id = 6,
                    Image = "cajonera.svg",
                    Available = false,
                    Name = "Cajonera",
                    Description = "La cajonera con espacios divididos.",
                    Price = 520,
                    CategoryId = productCategories[2].Id
                });

            //-----------------------------------------------------

            var orders = new Order[3]
            {
                new Order()
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    UserId = 3
                },
                new Order()
                {
                    Id = 2,
                    OrderDate = DateTime.UtcNow,
                    UserId = 4
                },
                new Order()
                {
                    Id = 3,
                    OrderDate = DateTime.UtcNow,
                    UserId = 3
                },
            };
            modelBuilder.Entity<Order>().HasData(orders);

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail()
                {
                    Id = 1,
                    OrderId = orders[0].Id,
                    ProductId = 1,
                    Quantity = 3,
                    Price = 1260
                },
                new OrderDetail()
                {
                    Id = 2,
                    OrderId = orders[0].Id,
                    ProductId = 3,
                    Quantity = 5,
                    Price = 2600
                },
                new OrderDetail()
                {
                    Id = 3,
                    OrderId = orders[1].Id,
                    ProductId = 2,
                    Quantity = 2,
                    Price = 640
                },
                new OrderDetail()
                {
                    Id = 4,
                    OrderId = orders[1].Id,
                    ProductId = 4,
                    Quantity = 1,
                    Price = 520
                },
                new OrderDetail()
                {
                    Id = 5,
                    OrderId = orders[2].Id,
                    ProductId = 2,
                    Quantity = 3,
                    Price = 960
                },
                new OrderDetail()
                {
                    Id = 6,
                    OrderId = orders[2].Id,
                    ProductId = 4,
                    Quantity = 4,
                    Price = 2080
                });

            var users = new User[4]
            {
                new User()
                {
                    Id = 1,
                    UserName = "Elias",
                    Password = "has3vgHdhDfbsSajsd",
                    Email = "usuario1@gmail.com",
                    Role = "Admin"
                },
                new User()
                {
                    Id = 2,
                    UserName = "Mauri",
                    Password = "sdDEasdegR12FgDsnasfdA",
                    Email = "usuario2@gmail.com",
                    Role = "Admin"
                },
                new User()
                {
                    Id = 3,
                    UserName = "cliente1",
                    Password = "sdDEasfegR12sgDsnasfdA",
                    Email = "usuario3@gmail.com",
                    Role = "Cliente"
                },
                new User()
                {
                    Id = 4,
                    UserName = "cliente2",
                    Password = "sdDEasqegR12FgDsnasudA",
                    Email = "usuario4@gmail.com",
                    Role = "Cliente"
                }
            };
            modelBuilder.Entity<User>().HasData(users);

            base.OnModelCreating(modelBuilder);
        }
    }
}
