using System;
using System.Threading.Tasks;

namespace Hoebeke.Domain.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _db = new CustomerContext();

        public async Task<int> InsertCustomerAsync(Customer customer)
        {
            try
            {
                _db.Customers.Add(customer);
                await _db.SaveChangesAsync();
                return customer.Id;
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
