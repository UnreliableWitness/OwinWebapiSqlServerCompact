using System;
using System.Threading.Tasks;
using System.Web.Http;
using Hoebeke.Domain;
using Hoebeke.Domain.Repositories;

namespace Hoebeke.WebApi
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public Customer Get(string customerId)
        {
            return new Customer()
            {
                Id = Int32.Parse(customerId),
                Name = "john doe"
            };
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _customerRepository.InsertCustomerAsync(customer);

            return Ok(customer.Id);
        }
    }
}
