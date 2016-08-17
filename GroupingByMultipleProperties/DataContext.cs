using System.Data.Entity;

namespace GroupingByMultipleProperties
{
    public class DataContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
    }
}
