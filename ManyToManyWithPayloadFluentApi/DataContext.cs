using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyWithPayloadFluentApi
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Order>()
            //    .HasMany(order => order.OrderItems)
            //    .WithRequired(orderItems => orderItems.Order)
            //    .HasForeignKey()
            
            
        }
    }
}
