using System.Data.Entity;

namespace SplittingTableAmongMultipleEntities_FluentAPI
{
    public class DataContext : DbContext
    {
        public DbSet<PhotoFullImage> FullImages { get; set; }

        public DbSet<PhotoThumbnail> Thumbnails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhotoThumbnail>()
                .HasKey(p => p.Id)
                .HasRequired(p => p.PhotoFullImage)
                .WithRequiredPrincipal(p => p.PhotoThumbnail);

            modelBuilder.Entity<PhotoFullImage>().HasKey(p => p.Id);


            // another way for naming tables, this will create table name, SplittingTableAmongMultipleEntities.Photograph
            //modelBuilder.Entity<PhotoThumbnail>().ToTable("Photograph", "SplittingTableAmongMultipleEntities");
            //modelBuilder.Entity<PhotoFullImage>().ToTable("Photograph", "SplittingTableAmongMultipleEntities");

            modelBuilder.Entity<PhotoThumbnail>().ToTable("Photograph");
            modelBuilder.Entity<PhotoFullImage>().ToTable("Photograph");
        }
    }
}
