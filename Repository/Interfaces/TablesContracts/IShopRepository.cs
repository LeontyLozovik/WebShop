using Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.TablesContracts
{
    public interface IShopRepository
    {
        Task<Shop> GetOneShopAsync(Guid shopId);
        void CreateShop(Shop shop);
        void UpdateShop(Shop shop);
        void DeleteShop(Shop shop);
    }
}
