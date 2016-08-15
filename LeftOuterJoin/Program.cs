using System;
using System.Linq;

namespace LeftOuterJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize and seed database
            using (var context = new DataContext())
            {
                var p1 = new Product { Name = "Trailrunner Backpack" };
                var p2 = new Product
                {
                    Name = "Green River Tent",
                    TopSelling = new TopSelling { Rating = 3 }
                };
                var p3 = new Product
                {
                    Name = "Prairie Home Dutch Oven",
                    TopSelling = new TopSelling { Rating = 4 }
                };
                var p4 = new Product
                {
                    Name = "QuickFire Fire Starter",
                    TopSelling = new TopSelling { Rating = 2 }
                };
                context.Products.Add(p1);
                context.Products.Add(p2);
                context.Products.Add(p3);
                context.Products.Add(p4);
                context.SaveChanges();
            }

            // query from database using navigation property 
            using (var context = new DataContext())
            {
                // using navigation property
                var productsQuerySyntax = from p in context.Products
                               orderby p.TopSelling.Rating descending
                               select p;

                var productsMethodSyntax = context.Products.OrderByDescending(p => p.TopSelling.Rating);

                Console.WriteLine("All products, including those without ratings");
                foreach (var product in productsQuerySyntax)
                {
                    Console.WriteLine("\t{0} [rating: {1}]", product.Name,
                    product.TopSelling == null ? "0"
                    : product.TopSelling.Rating.ToString());
                }
            }

            // query from database without using navigation property
            using (var context = new DataContext())
            {

                var productsQuerySyntax = from p in context.Products
                               join t in context.TopSellings on
                               // note how we project the results together into another
                               // sequence, entitled 'g' and apply the DefaultIfEmpty method
                               p.Id equals t.Id into g
                               from tps in g.DefaultIfEmpty()
                               orderby tps.Rating descending
                               select new
                               {
                                   Name = p.Name,
                                   Rating = tps.Rating == null ? 0 : tps.Rating
                               };

                var productsMethodSyntax = context.Products.GroupJoin(
                    inner: context.TopSellings,
                    innerKeySelector: p => p.Id,
                    outerKeySelector: t => t.Id,
                    resultSelector: (p, g) => new { p, g })
               .SelectMany(
                    collectionSelector: x => x.g.DefaultIfEmpty(),
                    resultSelector: (x, tps) => new { x.p, x.g, tps })
               .OrderByDescending(keySelector: x => x.tps.Rating)
               .Select(selector: x => new { x.p.Name, Rating = x.tps.Rating == null ? 0 : x.tps.Rating });

                Console.WriteLine("\nAll products, including those without ratings");
                foreach (var product in productsQuerySyntax)
                {
                    //if (product.Rating != 0)
                        Console.WriteLine("\t{0} [rating: {1}]", product.Name,
                        product.Rating.ToString());
                }
            }

            Console.ReadKey();
        }
    }
}
