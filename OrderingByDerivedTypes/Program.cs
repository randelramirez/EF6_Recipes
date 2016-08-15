using System;
using System.Linq;

namespace OrderingByDerivedTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                context.Media.Add(new Article
                {
                    Title = "Woodworkers' Favorite Tools"
                });
                context.Media.Add(new Article
                {
                    Title = "Building a Cigar Chair"
                });
                context.Media.Add(new Video
                {
                    Title = "Upholstering the Cigar Chair"
                });
                context.Media.Add(new Video
                {
                    Title = "Applying Finish to the Cigar Chair"
                });
                context.Media.Add(new Picture
                {
                    Title = "Photos of My Cigar Chair"
                });
                context.Media.Add(new Video
                {
                    Title = "Tour of My Woodworking Shop"
                });
                context.SaveChanges();
            }

            /*
                When we use Table per Hierarchy inheritance, we leverage a column in the table to distinguish which derived type
                represents any given row. This column, often referred to as the discriminator column, can’t be mapped to a property
                of the base entity. Because we don’t have a property with the discriminator value, we need to create a variable to hold
                comparable discriminator values so that we can do the sort. To do this, we use a LINQ let clause, which creates a
                the mediatype variable. We use a conditional statement to assign an integer to this variable based on the type of the
                media. For Articles, we assign the value 1. For Videos, we assign the value 2. We assign a value of 3 to anything else,
                which will always be of type Picture because no other derived types remain.
             */

            using (var context = new DataContext())
            {
                var allMedia = from m in context.Media
                               let mediatype = m is Article ? 1 :
                               m is Video ? 2 : 3
                               orderby mediatype
                               select m;
                var allMediaMethodSyntax = context.Media.Select(m => 
                    new { m = m, mediatype = m is Article ? 1 : m is Video ? 2 : 3 })
                    .OrderBy(m => m.mediatype).Select(m => m.m);

                Console.WriteLine("All Media sorted by type...");
                foreach (var media in allMedia)
                {
                    Console.WriteLine("Title: {0} [{1}]", media.Title, media.GetType().Name);
                }
            }

            Console.ReadKey();
        }
    }
}
