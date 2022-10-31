using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Repository.DataModels;
using Repository.Interfaces;
using System.Security.Claims;
using WebShop.DataTransferObject;
using WebShop.Filters;

namespace WebShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;
        private IMemoryCache _memoryCache;
        private ILogger<ProductController> _logger;

        public ProductController(IRepositoryManager repositoryManager, IMapper mapper, IMemoryCache memoryCache, 
            ILogger<ProductController> logger)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _logger = logger;
        }
        public async Task<IActionResult> AllProducts()
        {
            var products = await _repositoryManager.ProductRepository.GetDeletedOrNotProductsAsync(false);
            _logger.Log(LogLevel.Information, "Success geting all products");
            return View(products);
        }

        [ServiceFilter(typeof(ValidateId))]
        public async Task<ActionResult> Details(Guid id)
        {
            FullProductDTO productInfoDTO;
            if (!_memoryCache.TryGetValue(id, out productInfoDTO))
            {
                var product = await _repositoryManager.ProductRepository.GetOneProductAsync(id);
                _logger.Log(LogLevel.Information, "Success get one products");
                var shop = await _repositoryManager.ShopRepository.GetOneShopAsync(product.ShopId);
                _logger.Log(LogLevel.Information, "Success get one shop");

                var productFilds = _mapper.Map<FullProductDTO>(product);
                productInfoDTO = _mapper.Map<Shop, FullProductDTO>(shop, productFilds);
                _logger.Log(LogLevel.Information, "Success map");

                _memoryCache.Set(id, productInfoDTO, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
            }           

            return View(productInfoDTO);
        }
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(ValidateModel))]
        public async Task<IActionResult> Create(FullProductDTO productInfoDTO)
        {
            var product = _mapper.Map<Product>(productInfoDTO);
            var shop = _mapper.Map<Shop>(productInfoDTO);
            _logger.Log(LogLevel.Information, "Success map");

            _repositoryManager.ShopRepository.CreateShop(shop);
            _logger.Log(LogLevel.Information, "Success creating shop");

            product.Shop = shop;

            _repositoryManager.ProductRepository.CreateProduct(product);
            _logger.Log(LogLevel.Information, "Success creating product");

            await _repositoryManager.SaveAsync();

            return RedirectToAction("AllProducts");
        }

        [ServiceFilter(typeof(ValidateId))]
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _repositoryManager.ProductRepository.GetOneProductAsync(id);
            _logger.Log(LogLevel.Information, "Success get one product");
            var shop = await _repositoryManager.ShopRepository.GetOneShopAsync(product.ShopId);
            _logger.Log(LogLevel.Information, "Success get one shop");

            var productFilds = _mapper.Map<ProductUpdateDTO>(product);
            var productUpdateDTO = _mapper.Map<Shop, ProductUpdateDTO>(shop, productFilds);
            _logger.Log(LogLevel.Information, "Success map");

            return PartialView(productUpdateDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(ValidateModel))]
        public async Task<IActionResult> Edit(ProductUpdateDTO productUpdteDTO)
        {
            var product = _mapper.Map<Product>(productUpdteDTO);
            var shop = _mapper.Map<Shop>(productUpdteDTO);
            _logger.Log(LogLevel.Information, "Success map");

            product.Shop = shop;

            _repositoryManager.ProductRepository.UpdateProduct(product);
            await _repositoryManager.SaveAsync();
            _logger.Log(LogLevel.Information, "Success update product");

            _memoryCache.Remove(productUpdteDTO.Id);

            return RedirectToAction("Details", new { id = product.Id });
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _repositoryManager.ProductRepository.GetOneProductAsync(id);
            _logger.Log(LogLevel.Information, "Success get one product");

            product.IsDeleted = true;

            _repositoryManager.ProductRepository.UpdateProduct(product);
            await _repositoryManager.SaveAsync();
            _logger.Log(LogLevel.Information, "Success delete one product");

            _memoryCache.Remove(id);

            return RedirectToAction("AllProducts");
        }
    }
}
