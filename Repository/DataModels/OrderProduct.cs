using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataModels
{
    public class OrderProduct
    {
        public Order? Order { get; set; }
        public Guid OrderId { get; set; }
        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
