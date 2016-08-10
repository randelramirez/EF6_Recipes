using System;
using System.Linq;

namespace SettingDefaultValuesInAQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize and seed the database
            using (var context = new DataContext())
            {
                context.Employees.Add(new Employee
                {
                    Name = "Robin Rosen",
                    YearsWorked = 3
                });
                context.Employees.Add(new Employee { Name = "John Hancock" });
                context.SaveChanges();
            }

            // query the database and set default value if it's null
            using (var context = new DataContext())
            {
                Console.WriteLine("Employees (using LINQ)");

                // query syntax
                //var employees = from e in context.Employees
                //                select new { Name = e.Name, YearsWorked = e.YearsWorked ?? 0 };

                // method syntax
                var employees = context.Employees.Select(e => new { Name = e.Name, YearsWorked = e.YearsWorked ?? 0 });

                foreach (var employee in employees)
                {
                    Console.WriteLine("{0}, years worked: {1}", employee.Name,
                    employee.YearsWorked);
                }
            }

            Console.ReadKey();
        }
    }
}
