using System.ComponentModel.DataAnnotations;
using Repository.Data;

namespace WebShop.DataTransferObject
{
    public class OrderDTO
    {
        public Guid Id { get; set; }

        [Display(Name = "Status")]
        public OrderStatusEnum OrderStatus { get; set; }

        [Display(Name = "Customer Address")]
        public string CustomerAddress { get; set; }
    }
}
