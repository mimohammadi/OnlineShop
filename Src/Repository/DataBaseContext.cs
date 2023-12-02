using Domain.Models.Discount;
using Domain.Models.Order;
using Domain.Models.Product;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DataBaseContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DataBaseContext(DbContextOptions options)
            :base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG

            optionsBuilder
               .UseSqlServer("Server=localhost\\SQLEXPRESS01;Initial Catalog=OnlineShopDB;Persist Security Info=True;MultipleActiveResultSets=true;User ID=sa;Password=123;TrustServerCertificate=Yes");

#endif
            base.OnConfiguring(optionsBuilder);

        }
    }
}
