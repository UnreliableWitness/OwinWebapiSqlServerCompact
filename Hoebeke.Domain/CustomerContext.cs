using System.Data.Entity;

namespace Hoebeke.Domain
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
