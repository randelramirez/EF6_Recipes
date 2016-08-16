using System;
using System.Linq;

namespace PagingAndFiltering
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                context.Customers.Add(new Customer
                {
                    Name = "Roberts, Jill",
                    Email = " jroberts@abc.com"
                });
                context.Customers.Add(new Customer
                {
                    Name = "Robertson, Alice",
                    Email = " arob@gmail.com"
                });
                context.Customers.Add(new Customer
                {
                    Name = "Rogers, Steven",
                    Email = " srogers@termite.com"
                });
                context.Customers.Add(new Customer
                {
                    Name = "Roe, Allen",
                    Email = " allenr@umc.com"
                });
                context.Customers.Add(new Customer
                {
                    Name = "Jones, Chris",
                    Email = " cjones@ibp.com"
                });
                context.SaveChanges();
            }

            using (var context = new DataContext())
            {
                string match = "Ro";
                int pageIndex = 0;
                int pageSize = 3;

                var customers = context.Customers.Where(c => c.Name.StartsWith(match))
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize);
                Console.WriteLine("Customers Ro*");
                foreach (var customer in customers)
                {
                    Console.WriteLine("{0} [email: {1}]", customer.Name, customer.Email);
                }
            }

            Console.ReadKey();
        }
    }
}
