using Microsoft.EntityFrameworkCore;

using SalesOrderApi.Models;

namespace SalesOrderApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<SalesOrder> SalesOrders => Set<SalesOrder>();
    public DbSet<SalesOrderItem> SalesOrderItems => Set<SalesOrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SalesOrderItem>()
            .Property(p => p.UnitPrice)
            .HasPrecision(18, 2);
    }
}
