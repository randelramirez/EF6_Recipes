using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoiningOnMultipleColumns
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(a => a.Id)
                .HasMany(a => a.Orders)
                .WithRequired(a => a.Account)
                .HasForeignKey(a => a.AccountId);

            modelBuilder.Entity<Order>()
                .HasKey(a => a.Id);
        }
    }
}
