using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringRelatedEntities
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize and seed database
            using (var context = new DataContext())
            {
                var worker1 = new Worker { Name = "John Kearney" };
                var worker2 = new Worker { Name = "Nancy Roberts" };
                var worker3 = new Worker { Name = "Karla Gibbons" };
                context.Accidents.Add(new Accident
                {
                    Description = "Cuts and contusions",
                    Severity = 3,
                    Worker = worker1
                });
                context.Accidents.Add(new Accident
                {
                    Description = "Broken foot",
                    Severity = 4,
                    Worker = worker1
                });
                context.Accidents.Add(new Accident
                {
                    Description = "Fall, no injuries",
                    Severity = 1,
                    Worker = worker2
                });
                context.Accidents.Add(new Accident
                {
                    Description = "Minor burn",
                    Severity = 3,
                    Worker = worker2
                });
                context.Accidents.Add(new Accident
                {
                    Description = "Back strain",
                    Severity = 2,
                    Worker = worker3
                });
                context.SaveChanges();
            }

            using (var context = new DataContext())
            {
                // explicitly disable lazy loading
                // We’ve turned off lazy loading so that only the accidents in our filter are loaded.
                context.Configuration.LazyLoadingEnabled = false;
                var query = from w in context.Workers
                            select new
                            {
                                Worker = w,
                                Accidents = w.Accidents.Where(a => a.Severity > 2)
                            };
                // note query(IQUERYABLE), produces the same sql statement with either lazy loading enabled or disabled
                query.ToList();
                var workers = query.Select(r => r.Worker);
                Console.WriteLine("Workers with serious accidents...");
                foreach (var worker in workers)
                {
                    Console.WriteLine("{0} had the following accidents", worker.Name);
                    if (worker.Accidents.Count == 0)
                        Console.WriteLine("\t--None--");
                    foreach (var accident in worker.Accidents)
                    {
                        Console.WriteLine("\t{0}, severity: {1}",
                        accident.Description, accident.Severity.ToString());
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
