using Repository.DataModels;
using System.ComponentModel.DataAnnotations;
using Repository.Data;

namespace WebShop.DataTransferObject
{
    public class FullOrderDTO
    {
        public Guid Id { get; set; }

        [Display(Name = "Status")]
        public OrderStatusEnum OrderStatus { get; set; }

        [Display(Name = "Costumer Name")]
        public string CostumerName { get; set; }

        [Display(Name = "Costumer Address")]
        public string CostumerAddress { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
