using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturningMultipleResultSetsFromAStoredProcedure
{
    public class DataContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .HasKey(j => j.Id)
                .HasMany(j => j.Bids)
                .WithRequired(j => j.Job)
                .HasForeignKey(j => j.JobId);
        }
    }
}
