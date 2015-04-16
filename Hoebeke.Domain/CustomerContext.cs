using System.Data.Entity;
using System.Data.SqlServerCe;

namespace Hoebeke.Domain
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
            : base(new SqlCeConnection(@"Data Source=|DataDirectory|\Database.sdf;Persist Security Info=False;"), true)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<CustomerContext>());
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
