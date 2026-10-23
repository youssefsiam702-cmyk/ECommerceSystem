namespace ECommerceSystem.Models;

public class CustomerOrder { public int Id { get; set; } public DateTime OrderDate { get; set; } public int CustomerId { get; set; } public Customer Customer { get; set; } = null!; public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>(); }
