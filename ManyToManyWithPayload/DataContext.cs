using System.Data.Entity;

namespace ManyToManyWithPayload
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
