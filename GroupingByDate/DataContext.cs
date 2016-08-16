using System.Data.Entity;

namespace GroupingByDate
{
    public class DataContext : DbContext
    {
        public DbSet<Registration> Registrations { get; set; }
    }
}
