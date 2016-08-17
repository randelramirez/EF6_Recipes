using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoiningOnMultipleColumns
{
    /*
     You want to join two entity types on multiple properties.
     */

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                var a1 = new Account { City = "Raytown", State = "MO" };
                a1.Orders.Add(new Order
                {
                    Amount = 223.09M,
                    ShipCity = "Raytown",
                    ShipState = "MO"
                });
                a1.Orders.Add(new Order
                {
                    Amount = 189.32M,
                    ShipCity = "Olathe",
                    ShipState = "KS"
                });
                var a2 = new Account { City = "Kansas City", State = "MO" };
                a2.Orders.Add(new Order
                {
                    Amount = 99.29M,
                    ShipCity = "Kansas City",
                    ShipState = "MO"
                });
                var a3 = new Account { City = "North Kansas City", State = "MO" };
                a3.Orders.Add(new Order
                {
                    Amount = 102.29M,
                    ShipCity = "Overland Park",
                    ShipState = "KS"
                });
                context.Accounts.Add(a1);
                context.Accounts.Add(a2);
                context.Accounts.Add(a3);
                context.SaveChanges();
            }

            using (var context = new DataContext())
            {
                var orders = from o in context.Orders
                             join a in context.Accounts on
                             new { Id = o.AccountId, City = o.ShipCity, State = o.ShipState }
                             equals
                             new { Id = a.Id, City = a.City, State = a.State }
                             select o;

                var ordersMethodSyntax = context.Orders.Join(context.Accounts,
                    o => new { Id = o.AccountId, City = o.ShipCity, State = o.ShipState },
                    a => new { Id = a.Id, City = a.City, State = a.State },
                    (o, a) => o);

                Console.WriteLine("Orders shipped to the account's city, state...");
                foreach (var order in orders)
                {
                    Console.WriteLine("\tOrder {0} for {1}", order.AccountId.ToString(),
                    order.Amount.ToString());
                }
            }


            /*
                you could find all the accounts and then go through each Orders collection and find the orders
                that are in the same city and state as the account. For a small number of accounts, this may be a reasonable solution.
                But in general, it is best to push this sort of processing into the store layer where it can be handled much more
                efficiently.
                
                Out-of-the-gate, both Account and Order are joined by the AccountId property. However, in this solution, we
                form an explicit join by creating an anonymous type on each side of the equals clause for each of the entities. The
                anonymous construct is required when we join entities on more than one property. We need to make sure that both
                anonymous types are the same. They must have the same properties in the same order. Here, we are explicitly creating
                an inner-join relationship between the two tables on the database, meaning that orders to other cities and states
                would not be included due to the join condition.
             */
            Console.ReadKey();
        }
    }
}
