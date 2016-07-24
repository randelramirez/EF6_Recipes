using System.Data.Entity;

namespace SelfReferencingFluentApi
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .HasOptional(employee => employee.SupervisorEmployee)
                .WithMany(supervisor => supervisor.Subordinates)
                .HasForeignKey(subordinate => subordinate.Supervisor);
        }
    }
}
