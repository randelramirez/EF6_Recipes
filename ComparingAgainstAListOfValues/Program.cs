using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ComparingAgainstAListOfValues
{

    // You want to query entities in which a specific property value matches a value contained in a given list.
    class Program
    {
        static void Main(string[] args)
        {
            // initialize and seed database
            using (var context = new DataContext())
            {
                // add new test data
                var cat1 = new Category { Name = "Programming" };
                var cat2 = new Category { Name = "Databases" };
                var cat3 = new Category { Name = "Operating Systems" };
                context.Books.Add(new Book { Title = "F# In Practice", Category = cat1 });
                context.Books.Add(new Book { Title = "The Joy of SQL", Category = cat2 });
                context.Books.Add(new Book
                {
                    Title = "Windows 7: The Untold Story",
                    Category = cat3
                });
                context.SaveChanges();
            }

            using (var context = new DataContext())
            {
                Console.WriteLine("Books (using LINQ)");
                var cats = new List<string> { "Programming", "Databases" };
                
                // using query syntax
                //var books = from b in context.Books
                //            where cats.Contains(b.Category.Name)
                //            select b;
                
                // using method syntax
                var books = context.Books.Include(b => b.Category).Where(c => cats.Contains(c.Category.Name));

                foreach (var book in books)
                {
                    Console.WriteLine("'{0}' is in category: {1}", book.Title,
                    book.Category.Name);
                }
            }

            Console.ReadKey();
        }
    }
}
