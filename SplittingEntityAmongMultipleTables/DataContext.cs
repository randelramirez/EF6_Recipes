using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SplittingEntityAmongMultipleTables
{
    public class DataContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id)
                .Map(m =>
                {
                    m.Properties(p => new { p.Id, p.FirstName, p.LastName, p.Birthday });
                    m.ToTable("BasicInfo", "People"); // table name becomes People.BasicInfo
                })
                .Map(m =>
                {
                    m.Properties(p => new { p.Id, p.FavoriteColor, p.FavoriteFood, p.FavoriteQuote });
                    m.ToTable("DetailedInfo", "People"); // table name becomes People.DetailedInfo
                })
                .Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }

    }
}
