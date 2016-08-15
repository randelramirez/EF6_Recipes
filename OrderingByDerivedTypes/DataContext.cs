using System.Data.Entity;

namespace OrderingByDerivedTypes
{
    public class DataContext : DbContext
    {
        public DbSet<Media> Media { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>().Map<Article>(x => x.Requires("MediaType").HasValue(1));
            modelBuilder.Entity<Media>().Map<Picture>(x => x.Requires("MediaType").HasValue(2));
            modelBuilder.Entity<Media>().Map<Video>(x => x.Requires("MediaType").HasValue(3));
        }
    }
}
