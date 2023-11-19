using Microsoft.EntityFrameworkCore;
using Test1_Database_FinalProject.Entities;

namespace Test1_Database_FinalProject.Context;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<OrderEntity> Order { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<SupplierEntity> Suppliers { get; set; }

  
}
