using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyWithPayloadFluentApi
{
    // http://stackoverflow.com/questions/5434125/entity-framework-codefirst-many-to-many-relationship-with-additional-information
    // http://stackoverflow.com/questions/7050404/create-code-first-many-to-many-with-additional-fields-in-association-table
    // http://stackoverflow.com/questions/16490334/how-to-define-many-to-many-relationship-through-fluent-api-entity-framework

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                var order = new Order
                {

                    //OrderDate = new DateTime(2010, 1, 18)
                };
                var item = new Item
                {

                    Description = "Backpack",
                    Price = 29.97
                };

                var oi = new OrderItem { Order = order, Item = item, Count = 99 };


                //context.Orders.Add(order);
                context.OrderItems.Add(oi);
                context.SaveChanges();
                Console.WriteLine("first order: " + context.Orders.First().OrderItems.First().Item.Description);


            }
            Console.ReadKey();
        }
    }
}
