namespace WebShop.DataTransferObject
{
    public class ProductUpdateDTO
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public Guid ShopId { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
    }
}
