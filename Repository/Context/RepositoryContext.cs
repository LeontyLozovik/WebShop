using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using Repository.DataModels;
using Repository.RepositoryConfiguration;

namespace Repository.ApplicationContext
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        { 
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(table =>
            {
                table.HasMany(e => e.Products)
                     .WithMany(e => e.Orders)
                     .UsingEntity<OrderProduct>
                     (
                        product => product.HasOne(e => e.Product)
                                          .WithMany(e => e.OrderProducts)
                                          .HasForeignKey(e => e.ProductId),
                        order => order.HasOne(e => e.Order)
                                      .WithMany(e => e.OrderProducts)
                                      .HasForeignKey(e => e.OrderId)
                     );
            });
            modelBuilder.ApplyConfiguration(new ShopConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
        }
    }
}
