using Microsoft.EntityFrameworkCore;
using SQR.Backend.Models;

namespace SQR.Backend.Data
{
    public class ProductionContext : DbContext
    {
        public ProductionContext(DbContextOptions options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Production> Productions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Product>().HasKey(p => p.ProductCode);
            modelBuilder.Entity<Material>().HasKey(m => m.MaterialCode);
            modelBuilder.Entity<ProductMaterial>().HasKey(pm => new { pm.ProductCode, pm.MaterialCode });
            modelBuilder.Entity<User>().HasKey(u => u.Email);
            modelBuilder.Entity<Production>()
                .HasOne(p => p.Material)
                .WithMany()
                .HasForeignKey(p => p.MaterialCode);
        }
    }
}