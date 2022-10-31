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
    public class OrderProductRepository : RepositoryBase<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }
        public async Task<ICollection<OrderProduct>> GetOrderProductsByOrderIdAsync(Guid orderId) =>
            await FindByCondition(op => op.OrderId.Equals(orderId)).ToListAsync();
        public async Task<ICollection<OrderProduct>> GetOrderProductsByProductIdAsync(Guid productId) =>
            await FindByCondition(op => op.OrderId.Equals(productId)).ToListAsync();
    }
}
