using System.Data.Entity;

namespace FindingAMasterThatHasDetail
{
    public class DataContext : DbContext
    {
        public DbSet<BlogPost> Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasKey(b => b.Id)
                .HasMany(b => b.Comments)
                .WithRequired(c => c.BlogPost)
                .HasForeignKey(b => b.BlogId);

            // another way
            //modelBuilder.Entity<Comment>()
            //    .HasKey(c => c.Id)
            //    .HasRequired(c => c.BlogPost)
            //    .WithMany(c => c.Comments)
            //    .HasForeignKey(c => c.BlogId);

        }
    }
}
