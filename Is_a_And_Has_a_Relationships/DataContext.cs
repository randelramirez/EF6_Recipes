using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_a_And_Has_a_Relationships
{
    public class DataContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasKey(l => l.Id)
                 .Map(m =>
                 {
                     m.Properties(l => new { l.Id, l.Address, l.City, l.State, l.ZIPCode });
                     m.ToTable("Location"); 
                 })
                 .HasMany(l => l.Parks) // location has many parks 
                 .WithOptional(p => p.Office) // park has optional office
                 .HasForeignKey(p => p.OfficeLocationId); // park has optional location

            modelBuilder.Entity<Park>().HasKey(p => p.Id)
                .Map(m =>
                {
                    m.Properties(p => new { p.Id, p.Name, p.OfficeLocationId });
                    m.ToTable("Park");
                });


        }
    }
}
