using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Repository.DataModels;
using Repository;
using Repository.Interfaces;
using WebShop.DataTransferObject;

namespace WebShop.Middleware
{
    public class RealeProductAndShopDeleteMiddleware
    {
        private readonly RequestDelegate _next;

        public RealeProductAndShopDeleteMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context, IRepositoryManager repositoryManager)
        {
            var productList = await repositoryManager.ProductRepository.GetDeletedOrNotProductsAsync(true);
            if (productList.Count() != 0 && productList != null)
            {
                foreach (var product in productList)
                {
                    product.OrderProducts = await repositoryManager.OrderProductRepository
                        .GetOrderProductsByProductIdAsync(product.Id);
                    if (product.OrderProducts.Count != 0 && product.OrderProducts != null)
                    {
                        var shop = await repositoryManager.ShopRepository.GetOneShopAsync(product.ShopId);
                        repositoryManager.ProductRepository.DeleteProduct(product);
                        repositoryManager.ShopRepository.DeleteShop(shop);
                        await repositoryManager.SaveAsync();
                    }
                }
            }
            await _next.Invoke(context);
        }
    }
}
