using FurnitureStore.API.Entities;
using FurnitureStoreProject.API.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X500;

namespace FurnitureStore.API.DBContext
{
    public class FurnitureStoreContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

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
                .WithMany()
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

            ////-----------------------------------------------------

            //var users = new User[4]
            //{
            //    new User()
            //    {
            //        Id = 1,
            //        UserName = "Elias",
            //        Password = "has3vgHdhDfbsSajsd",
            //        Email = "usuario1@gmail.com",
            //        Role = "Admin"
            //    },
            //    new User()
            //    {
            //        Id = 2,
            //        UserName = "Mauri",
            //        Password = "sdDEasdegR12FgDsnasfdA",
            //        Email = "usuario2@gmail.com",
            //        Role = "Admin"
            //    },
            //    new User()
            //    {
            //        Id = 3,
            //        UserName = "cliente1",
            //        Password = "sdDEasfegR12sgDsnasfdA",
            //        Email = "usuario3@gmail.com",
            //        Role = "Cliente"
            //    },
            //    new User()
            //    {
            //        Id = 4,
            //        UserName = "cliente2",
            //        Password = "sdDEasqegR12FgDsnasudA",
            //        Email = "usuario4@gmail.com",
            //        Role = "Cliente"
            //    }
            //};
            //modelBuilder.Entity<User>().HasData(users);

            base.OnModelCreating(modelBuilder);
        }
    }
}
