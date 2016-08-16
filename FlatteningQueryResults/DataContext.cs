using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatteningQueryResults
{
    public class DataContext : DbContext
    {
        public DbSet<Associate> Associates { get; set; }

        public DbSet<AssociateSalary> AssociateSalaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Associate>()
                .HasKey(a => a.Id)
                .HasMany(a => a.AssociateSalaries)
                .WithRequired(a => a.Associate)
                .HasForeignKey(a => a.AssociateId);

            modelBuilder.Entity<AssociateSalary>()
                .HasKey(a => a.Id);
        }
    }
}
