using System;
using System.Linq;

namespace GroupingByMultipleProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize and seed the database
            using (var context = new DataContext())
            {

                // add new test data
                context.Events.Add(new Event
                {
                    Name = "TechFest 2010",
                    State = "TX",
                    City = "Dallas"
                });
                context.Events.Add(new Event
                {
                    Name = "Little Blue River Festival",
                    State = "MO",
                    City = "Raytown"
                });
                context.Events.Add(new Event
                {
                    Name = "Fourth of July Fireworks",
                    State = "MO",
                    City = "Raytown"
                });
                context.Events.Add(new Event
                {
                    Name = "BBQ Ribs Championship",
                    State = "TX",
                    City = "Dallas"
                });
                context.Events.Add(new Event
                {
                    Name = "Thunder on the Ohio",
                    State = "KY",
                    City = "Louisville"
                });
                context.SaveChanges();
            }

            /*
                When using the group by operator for multiple properties, we create an
                anonymous type to initially group the data. We use an into clause to send the groups to g, which is a second sequence
                created to hold the results of the query.
             */
            using (var context = new DataContext())
            {
                Console.WriteLine("Using LINQ");
                var results = from e in context.Events
                                  // create annonymous type to encapsulate composite
                                  // sort key of State and City
                              group e by new { e.State, e.City } into g
                              select new
                              {
                                  State = g.Key.State,
                                  City = g.Key.City,
                                  Events = g
                              };
                var resultsMethodSyntax = context.Events.GroupBy(e => new { State = e.State, City = e.City })
                    .Select(g => new { State = g.Key.State, City = g.Key.City, Events = g });

                Console.WriteLine("Events by State and City...");
                foreach (var item in results)
                {
                    Console.WriteLine("{0}, {1}", item.City, item.State);
                    foreach (var ev in item.Events)
                    {
                        Console.WriteLine("\t{0}", ev.Name);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
