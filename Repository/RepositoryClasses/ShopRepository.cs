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
    public class ShopRepository : RepositoryBase<Shop>, IShopRepository
    {
        public ShopRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<Shop> GetOneShopAsync(Guid shopId) =>
            await FindByCondition(shop => shop.Id.Equals(shopId))
                 .SingleOrDefaultAsync();
        public void CreateShop(Shop shop) =>
            Create(shop);
        public void UpdateShop(Shop shop) =>
            Update(shop);
        public void DeleteShop(Shop shop) =>
            Delete(shop);
    }
}
