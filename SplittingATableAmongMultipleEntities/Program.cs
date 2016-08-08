using SplittingAnEntityAmongMultipleTables;
using System;

namespace SplittingATableAmongMultipleEntities
{

    /*
     You have a table with some frequently used fields and a few large, but rarely needed fields. For performance reasons,
    you want to avoid needlessly loading these expensive fields on every query. You want to split the table across two or
    more entities.
     */

    // PhotoFullImage will be the class that contains " a few large, but rarely needed fields" which was mentioned above

    class Program
    {
        static void Main(string[] args)
        {
            byte[] thumbBits = new byte[100];
            byte[] fullBits = new byte[2000];
            using (var context = new DataContext())
            {
                var photo = new PhotoThumbnail
                {
                    Title = "My Dog",
                    ThumbnailImage = thumbBits
                };
                var fullImage = new PhotoFullImage { HighResolution = fullBits };
                photo.PhotoFullImage = fullImage;
                context.Thumbnails.Add(photo);


                var photo2 = new PhotoThumbnail
                {
                    Title = "My Dog",
                    ThumbnailImage = thumbBits
                };
                var fullImage2 = new PhotoFullImage { HighResolution = fullBits };
                fullImage2.PhotoThumbnail = photo2;
                context.FullImages.Add(fullImage2);

                // note: trying to save a PhotoFullImage without PhotoThumbnail will throw an exception
                //var fullImage3 = new PhotoFullImage { HighResolution = fullBits };
                //context.FullImages.Add(fullImage3);

                context.SaveChanges();
               
            }

            Console.ReadKey();
        }
    }
}
