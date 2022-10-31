using Microsoft.EntityFrameworkCore;
using Repository.ApplicationContext;
using Repository.DataModels;
using Repository.Interfaces.TablesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryClasses
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync() =>
            await FindAll()
                 .OrderBy(order => order.OrderStatus)
                 .ToListAsync();
        public async Task<Order> GetOneOrderAsync(Guid orderId) =>
            await FindByCondition(order => order.Id.Equals(orderId))
                 .SingleOrDefaultAsync();
        public void UpdateOrder(Order order) =>
            Update(order);
    }
}
