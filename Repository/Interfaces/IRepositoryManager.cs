using Repository.Interfaces.TablesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepositoryManager
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IShopRepository ShopRepository { get; }
        IOrderProductRepository OrderProductRepository { get; }
        Task SaveAsync();
        void TrackClear();
    }
}
