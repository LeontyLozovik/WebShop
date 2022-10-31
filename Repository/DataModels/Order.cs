using Repository.Data;

namespace Repository.DataModels
{
    public class Order
    {
        public Guid Id { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public ICollection<Product> Products { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
