using Repository.ApplicationContext;
using Repository.Interfaces;
using Repository.Interfaces.TablesContracts;
using Repository.RepositoryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IShopRepository _shopRepository;
        private IOrderProductRepository _orderProductRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_repositoryContext);

                return _customerRepository;
            }
        }
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_repositoryContext);

                return _orderRepository;
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_repositoryContext);

                return _productRepository;
            }
        }
        public IShopRepository ShopRepository
        {
            get
            {
                if (_shopRepository == null)
                    _shopRepository = new ShopRepository(_repositoryContext);

                return _shopRepository;
            }
        }
        public IOrderProductRepository OrderProductRepository
        {
            get
            { 
                if(_orderProductRepository == null)
                    _orderProductRepository = new OrderProductRepository(_repositoryContext);

                return _orderProductRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
        public void TrackClear() => _repositoryContext.ChangeTracker.Clear();
    }
}
