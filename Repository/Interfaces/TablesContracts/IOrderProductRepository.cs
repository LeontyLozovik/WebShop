using Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.TablesContracts
{
    public interface IOrderProductRepository
    {
        Task<ICollection<OrderProduct>> GetOrderProductsByOrderIdAsync(Guid orderId);
        Task<ICollection<OrderProduct>> GetOrderProductsByProductIdAsync(Guid productId);
    }
}
