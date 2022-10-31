using System.ComponentModel.DataAnnotations;

namespace WebShop.DataTransferObject
{
    public class FullProductDTO
    {
        public Guid Id { get; set; }

        [Display(Name = "Product name")]
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }

        [Display(Name = "Shop name")]
        public string ShopName { get; set; }
        public string Address { get; set; }
    }
}
