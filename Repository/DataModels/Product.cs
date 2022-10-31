namespace Repository.DataModels
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public Guid ShopId { get; set; }
        public Shop? Shop { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
