using System.Data.Entity;

namespace SelfReferencingDataAnnotation
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

    }
}
