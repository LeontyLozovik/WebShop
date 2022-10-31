using Repository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.TablesContracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<Product>> GetDeletedOrNotProductsAsync(bool isDeleted);
        Task<Product> GetOneProductAsync(Guid productId);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
