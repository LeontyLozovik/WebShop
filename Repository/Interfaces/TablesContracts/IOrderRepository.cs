using Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.TablesContracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOneOrderAsync(Guid orderId);
        void UpdateOrder(Order order);
    }
}
