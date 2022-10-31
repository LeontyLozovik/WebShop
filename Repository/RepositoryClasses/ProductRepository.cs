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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Product>> GetProductsAsync() =>
            await FindAll()
                 .ToListAsync();
        public async Task<IEnumerable<Product>> GetDeletedOrNotProductsAsync(bool iaDeleted) =>
            await FindByCondition(product => product.IsDeleted == iaDeleted)
                 .ToListAsync();
        public async Task<Product> GetOneProductAsync(Guid productID) =>
            await FindByCondition(product => product.Id.Equals(productID))
                  .SingleOrDefaultAsync();
        public void CreateProduct(Product product) =>
             Create(product);
        public void UpdateProduct(Product product) =>
            Update(product);
        public void DeleteProduct(Product product) =>
            Delete(product);
    }
}
