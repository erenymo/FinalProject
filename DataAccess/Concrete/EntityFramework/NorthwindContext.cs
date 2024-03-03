using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

// Context : DB tabloları ile proje Classlarını bağlamak
public class NorthwindContext:DbContext
{
    // projen hangi veritabanı ile ilişkili oldugunu belirttiğin method
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=Northwind;TrustServerCertificate=True;User=SA;Password=erenbalta342115");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}
