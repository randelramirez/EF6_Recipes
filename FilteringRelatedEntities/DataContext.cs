using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringRelatedEntities
{
    public class DataContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }

        public DbSet<Accident> Accidents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .HasKey(w => w.Id)
                .HasMany(w => w.Accidents)
                .WithRequired(w => w.Worker)
                .HasForeignKey(w => w.WorkerId);

            modelBuilder.Entity<Accident>()
                .HasKey(a => a.Id);

        }
    }
}
