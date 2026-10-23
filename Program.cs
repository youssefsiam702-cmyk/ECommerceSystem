using ECommerceSystem.Models;
using ECommerceSystem.Data;
using Microsoft.EntityFrameworkCore;
using var db = new AppDbContext();
db.Database.EnsureCreated();
if (!db.Categories.Any()) {
 var electronics=new Category{Name="Electronics"}; var books=new Category{Name="Books"};
 var customer=new Customer{Name="Mona Ali",Email="mona@example.com"};
 var phone=new Product{Name="Smartphone",Price=12000m,Category=electronics};
 var book=new Product{Name="LINQ Guide",Price=350m,Category=books};
 db.Orders.Add(new CustomerOrder{OrderDate=DateTime.Today,Customer=customer,OrderDetails=new List<OrderDetail>{new(){Product=phone,Quantity=1},new(){Product=book,Quantity=2}}}); db.SaveChanges();
}
Console.WriteLine("=== E-Commerce System ===");
foreach(var o in db.Orders.Include(x=>x.Customer).Include(x=>x.OrderDetails).ThenInclude(x=>x.Product)) {
 Console.WriteLine($"Order #{o.Id} | Customer: {o.Customer.Name} | Date: {o.OrderDate:d}");
 foreach(var d in o.OrderDetails) Console.WriteLine($"  {d.Product.Name} x {d.Quantity} = {d.Product.Price*d.Quantity:C}");
}
Console.WriteLine("\nProducts by category:");
foreach(var c in db.Categories.Include(x=>x.Products)) Console.WriteLine($"{c.Name}: {string.Join(", ",c.Products.Select(p=>p.Name))}");
