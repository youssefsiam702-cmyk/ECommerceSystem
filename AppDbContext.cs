using Microsoft.EntityFrameworkCore;
using ECommerceSystem.Models;
namespace ECommerceSystem.Data;
public class AppDbContext : DbContext {
 public DbSet<Product> Products => Set<Product>(); public DbSet<Category> Categories => Set<Category>(); public DbSet<Customer> Customers => Set<Customer>(); public DbSet<CustomerOrder> Orders => Set<CustomerOrder>(); public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
 protected override void OnConfiguring(DbContextOptionsBuilder o) => o.UseSqlite("Data Source=ecommerce.db");
 protected override void OnModelCreating(ModelBuilder m) {
  m.Entity<Product>().HasOne(p=>p.Category).WithMany(c=>c.Products).HasForeignKey(p=>p.CategoryId);
  m.Entity<CustomerOrder>().HasOne(o=>o.Customer).WithMany(c=>c.Orders).HasForeignKey(o=>o.CustomerId);
  m.Entity<OrderDetail>().HasKey(x=>new{x.OrderId,x.ProductId});
  m.Entity<OrderDetail>().HasOne(x=>x.Order).WithMany(o=>o.OrderDetails).HasForeignKey(x=>x.OrderId);
  m.Entity<OrderDetail>().HasOne(x=>x.Product).WithMany(p=>p.OrderDetails).HasForeignKey(x=>x.ProductId);
  m.Entity<Product>().Property(p=>p.Price).HasPrecision(10,2);
 }
}