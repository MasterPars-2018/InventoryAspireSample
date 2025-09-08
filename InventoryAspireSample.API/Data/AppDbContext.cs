using InventoryAspireSample.Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace InventoryAspireSample.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Product => Set<Product>();

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(200);
            e.Property(x => x.Price).HasPrecision(18, 2);
            e.Property(x => x.Category).HasMaxLength(100);
        });

        // ✅ Seed 10 static rows
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Description = "15-inch business laptop", Price = 1200.00m, Stock = 15, Category = "Electronics", CreatedAt = new DateTime(2025, 01, 01), IsActive = true },
            new Product { Id = 2, Name = "Smartphone", Description = "Latest Android smartphone", Price = 800.00m, Stock = 30, Category = "Electronics", CreatedAt = new DateTime(2025, 01, 02), IsActive = true },
            new Product { Id = 3, Name = "Office Chair", Description = "Ergonomic office chair", Price = 250.00m, Stock = 20, Category = "Furniture", CreatedAt = new DateTime(2025, 01, 03), IsActive = true },
            new Product { Id = 4, Name = "Desk Lamp", Description = "LED desk lamp", Price = 40.00m, Stock = 50, Category = "Home", CreatedAt = new DateTime(2025, 01, 04), IsActive = true },
            new Product { Id = 5, Name = "Backpack", Description = "Waterproof travel backpack", Price = 60.00m, Stock = 25, Category = "Accessories", CreatedAt = new DateTime(2025, 01, 05), IsActive = true },
            new Product { Id = 6, Name = "Headphones", Description = "Noise-cancelling headphones", Price = 150.00m, Stock = 40, Category = "Electronics", CreatedAt = new DateTime(2025, 01, 06), IsActive = true },
            new Product { Id = 7, Name = "Running Shoes", Description = "Lightweight running shoes", Price = 100.00m, Stock = 35, Category = "Sportswear", CreatedAt = new DateTime(2025, 01, 07), IsActive = true },
            new Product { Id = 8, Name = "Coffee Maker", Description = "Automatic drip coffee maker", Price = 90.00m, Stock = 10, Category = "Appliances", CreatedAt = new DateTime(2025, 01, 08), IsActive = true },
            new Product { Id = 9, Name = "Bluetooth Speaker", Description = "Portable Bluetooth speaker", Price = 70.00m, Stock = 45, Category = "Electronics", CreatedAt = new DateTime(2025, 01, 09), IsActive = true },
            new Product { Id = 10, Name = "Notebook", Description = "Hardcover ruled notebook", Price = 12.50m, Stock = 100, Category = "Stationery", CreatedAt = new DateTime(2025, 01, 10), IsActive = true }
        );
    }
}




