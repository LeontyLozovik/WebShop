namespace Repository.DataModels
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Product? Product { get; set; }
    }
}
