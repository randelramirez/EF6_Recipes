using System.Data.Entity;

namespace ManyToManyWithPayloadFluentApi
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configure primary keys for Order and Item
            //modelBuilder.Entity<Order>().HasKey(o => o.Id);
            //modelBuilder.Entity<Item>().HasKey(i => i.Id);

            // configure primary key for OrderItem
            modelBuilder.Entity<OrderItem>()
                .HasKey(orderItem => new { orderItem.OrderId, orderItem.ItemId });

            modelBuilder.Entity<OrderItem>()
                .HasRequired(orderItem => orderItem.Order)
                .WithMany(order => order.OrderItems)
                .HasForeignKey(orderItem => orderItem.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasRequired(orderItem => orderItem.Item)
                .WithMany(item => item.OrderItems)
                .HasForeignKey(orderItem => orderItem.OrderId);
        }
    }
}
