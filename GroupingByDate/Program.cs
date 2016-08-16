using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.ReadKey();
        }
    }
}
