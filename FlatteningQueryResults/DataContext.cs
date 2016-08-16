using System.Data.Entity;

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
