using System.Data.Entity;

namespace PagingAndFiltering
{
    public class DataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
