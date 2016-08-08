using SplittingATableAmongMultipleEntities;
using System.Data.Entity;

namespace SplittingAnEntityAmongMultipleTables
{
    public class DataContext : DbContext
    {
        public DbSet<PhotoFullImage> FullImages { get; set; }

        public DbSet<PhotoThumbnail> Thumbnails { get; set; }

    }
}
