using System.Threading.Tasks;

namespace Hoebeke.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<int> InsertCustomerAsync(Customer customer);
    }
}
