using Microsoft.EntityFrameworkCore;
using Repository.ApplicationContext;
using Repository.DataModels;
using Repository.Interfaces.TablesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository.RepositoryClasses
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        { }
        public async Task<Customer> GetOneCustomerAsync(Guid customerId) =>
            await FindByCondition(customer => customer.Id.Equals(customerId))
                 .SingleOrDefaultAsync();
    }
}
