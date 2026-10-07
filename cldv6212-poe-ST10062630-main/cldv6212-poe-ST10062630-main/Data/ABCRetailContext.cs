using Microsoft.EntityFrameworkCore;
using ST10062630_CLDV6212_POE.Models;
namespace ST10062630_CLDV6212_POE.Data
{
    public class ABCRetailContext : DbContext
    {
        public ABCRetailContext(DbContextOptions<ABCRetailContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the relationship between Order and Customer
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            // Define the relationship between Order and Product
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
