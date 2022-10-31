using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Repository;
using Repository.ApplicationContext;
using Repository.Data;
using Repository.DataModels;
using Repository.Interfaces;
using WebShop.DataTransferObject;
using WebShop.Filters;

namespace WebShop.Controllers
{
    [Authorize(Roles = "Courier, Admin")]
    public class OrderController : Controller
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;
        private IMemoryCache _memoryCache;
        private ILogger<OrderController> _logger;
        public OrderController(IRepositoryManager repositoryManager, IMapper mapper, IMemoryCache memoryCache, 
            ILogger<OrderController> logger)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _logger = logger;
        }
        public async Task<IActionResult> AllOrders()
        {
            List<OrderDTO> orderLists = new List<OrderDTO>();

            var orders = await _repositoryManager.OrderRepository.GetAllOrdersAsync();
            _logger.Log(LogLevel.Information, "Success get one order");

            foreach (var order in orders)
            {
                var customer = await _repositoryManager.CustomerRepository.GetOneCustomerAsync(order.CustomerId);
                _logger.Log(LogLevel.Information, "Success get one costumer");

                var orderFilds = _mapper.Map<OrderDTO>(order);
                var orderListDTO = _mapper.Map<Customer, OrderDTO>(customer, orderFilds);

                _logger.Log(LogLevel.Information, "Success map");

                orderLists.Add(orderListDTO);
            }

            return View(orderLists);
        }

        [ServiceFilter(typeof(ValidateId))]
        public async Task<IActionResult> Details(Guid id)
        {
            FullOrderDTO oneOrderDTO;
            if (!_memoryCache.TryGetValue(id, out oneOrderDTO))
            {
                var order = await _repositoryManager.OrderRepository.GetOneOrderAsync(id);
                _logger.Log(LogLevel.Information, "Success get one order");
                var orderFilds = _mapper.Map<OrderDTO>(order);
                _logger.Log(LogLevel.Information, "Success map");

                order.Customer = await _repositoryManager.CustomerRepository.GetOneCustomerAsync(order.CustomerId);
                _logger.Log(LogLevel.Information, "Success get one costumer");
                oneOrderDTO = _mapper.Map<FullOrderDTO>(orderFilds);
                oneOrderDTO = _mapper.Map<Customer, FullOrderDTO>(order.Customer, oneOrderDTO);
                _logger.Log(LogLevel.Information, "Success map");

                order.OrderProducts = await _repositoryManager.OrderProductRepository.GetOrderProductsByOrderIdAsync(order.Id);
                _logger.Log(LogLevel.Information, "Success get orderProducts");
                List<ProductDTO> productDTOList = new List<ProductDTO>();

                foreach (var op in order.OrderProducts)
                {
                    var product = await _repositoryManager.ProductRepository.GetOneProductAsync(op.ProductId);
                    _logger.Log(LogLevel.Information, "Success get one product");
                    var productDTO = _mapper.Map<ProductDTO>(product);
                    _logger.Log(LogLevel.Information, "Success map");
                    productDTOList.Add(productDTO);
                }

                oneOrderDTO.Products = productDTOList;

                _memoryCache.Set(id, oneOrderDTO, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                });
            }        

            return View(oneOrderDTO);
        }

        [Authorize(Roles = "Admin")]
        [ServiceFilter(typeof(ValidateId))]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            var order = await _repositoryManager.OrderRepository.GetOneOrderAsync(id);
            _logger.Log(LogLevel.Information, "Success get one order");

            if (order.OrderStatus.Equals(OrderStatusEnum.Complete))
                order.OrderStatus = OrderStatusEnum.Active;
            else
                order.OrderStatus = OrderStatusEnum.Complete;

            _logger.Log(LogLevel.Information, "Success chenging status");

            _repositoryManager.OrderRepository.UpdateOrder(order);
            await _repositoryManager.SaveAsync();
            _logger.Log(LogLevel.Information, "Success updete order");

            _memoryCache.Remove(id);

            return RedirectToAction("Details", new { id = id });
        }
    }
}
