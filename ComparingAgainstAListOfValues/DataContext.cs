using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingAgainstAListOfValues
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id)
                .HasRequired(b => b.Category) // a book has zero-one relationship with categories
                .WithMany(b => b.Books) // category has many books
                .HasForeignKey(b => b.CategoryId);
        }
    }
}
