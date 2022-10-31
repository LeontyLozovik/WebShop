namespace Repository.DataModels
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
