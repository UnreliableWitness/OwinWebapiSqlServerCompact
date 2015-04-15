using System;
using System.Threading.Tasks;

namespace Hoebeke.Domain.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext _db = new CustomerContext();

        public CustomerRepository()
        {
            
        }

        public async Task<int> InsertCustomerAsync(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return customer.Id;
        }
    }
}
