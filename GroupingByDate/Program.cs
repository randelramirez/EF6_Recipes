using System;
using System.Data.Entity;
using System.Linq;

namespace GroupingByDate
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                context.Registrations.Add(new Registration
                {
                    StudentName = "Jill Rogers",
                    RegistrationDate = DateTime.Parse("12/03/2009 9:30 pm")
                });
                context.Registrations.Add(new Registration
                {
                    StudentName = "Steven Combs",
                    RegistrationDate = DateTime.Parse("12/03/2009 10:45 am")
                });
                context.Registrations.Add(new Registration
                {
                    StudentName = "Robin Rosen",
                    RegistrationDate = DateTime.Parse("12/04/2009 11:18 am")
                });
                context.Registrations.Add(new Registration
                {
                    StudentName = "Allen Smith",
                    RegistrationDate = DateTime.Parse("12/04/2009 3:31 pm")
                });
                context.SaveChanges();
            }

            using (var context = new DataContext())
            {
                var groups = from r in context.Registrations
                                 // leverage built-in TruncateTime function to extract date portion
                             group r by DbFunctions.TruncateTime(r.RegistrationDate) into g
                             select g;

                var groupsMethodSyntax = context.Registrations.GroupBy(r => DbFunctions.TruncateTime(r.RegistrationDate)).Select(g => g);

                foreach (var element in groups)
                {
                    Console.WriteLine("Registrations for {0}",
                    ((DateTime)element.Key).ToShortDateString());
                    foreach (var registration in element)
                    {
                        Console.WriteLine("\t{0}", registration.StudentName);
                    }
                }
            }

            /*
                The key to grouping the registrations by the date portion of the RegistrationDate property is to use the Truncate()
                function. This built-in Entity Framework function, contained in the DbFunctions class, extracts just the date portion
                of the DateTime value. The built-in DbFunctions contain a wide array of formatting, aggregation, string manipulation,
                date-time, and mathematical services, and they are found in the System.Data.Entity namespace. The legacy
                class, EntityFunctions, used prior to Entity Framework 6, will still work with Entity Framework 6, but will give you
                a compiler warning suggesting you move to the DbFunctions class.
             */
            Console.ReadKey();
        }
    }
}
