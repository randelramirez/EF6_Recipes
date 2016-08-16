using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatteningQueryResults
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                var assoc1 = new Associate { Name = "Janis Roberts" };
                var assoc2 = new Associate { Name = "Kevin Hodges" };
                var assoc3 = new Associate { Name = "Bill Jordan" };
                var salary1 = new AssociateSalary
                {
                    Salary = 39500M,
                    SalaryDate = DateTime.Parse("8/4/09")
                };
                var salary2 = new AssociateSalary
                {
                    Salary = 41900M,
                    SalaryDate = DateTime.Parse("2/5/10")
                };
                var salary3 = new AssociateSalary
                {
                    Salary = 33500M,
                    SalaryDate = DateTime.Parse("10/08/09")
                };
                assoc2.AssociateSalaries.Add(salary1);
                assoc2.AssociateSalaries.Add(salary2);
                assoc3.AssociateSalaries.Add(salary3);
                context.Associates.Add(assoc1);
                context.Associates.Add(assoc2);
                context.Associates.Add(assoc3);
                context.SaveChanges();
            }

            using (var context = new DataContext())
            {
                Console.WriteLine("Using LINQ...");
                var allHistory = from a in context.Associates
                                 from ah in a.AssociateSalaries.DefaultIfEmpty()
                                 orderby a.Name
                                 select new
                                 {
                                     Name = a.Name,
                                     Salary = (decimal?)ah.Salary,
                                     Date = (DateTime?)ah.SalaryDate
                                 };
                var allHistoryMethodSyntax = context.Associates.SelectMany(a => a.AssociateSalaries.DefaultIfEmpty(), (a, ah) => new { a = a, ah = ah })
                    .OrderBy(h => h.a.Name).Select(h => new {
                        Name = h.a.Name,
                        Salary = (decimal?)h.ah.Salary,
                        Date = (DateTime?)h.ah.SalaryDate
                    });

                Console.WriteLine("Associate Salary History");
                foreach (var history in allHistory)
                {
                    if (history.Salary.HasValue)
                        Console.WriteLine("{0} Salary on {1} was {2}", history.Name,
                        history.Date.Value.ToShortDateString(),
                        history.Salary.Value.ToString("C"));
                    else
                        Console.WriteLine("{0} --", history.Name);
                }
            }

            Console.ReadKey();
        }
    }
}
