using System;
using System.Data.SqlClient;

namespace UpdatingWithNativeSQLStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            // seed and create the database
            using (DataContext context = new DataContext())
            {
                // note how using the following syntax with parameter place holders of @p0 and @p1
                // automatically create the ADO.NET SqlParameters object for you
                var sql = @"Insert into Payments(Amount, Vendor) Values (@p0, @p1)";
                var rowCount = context.Database.ExecuteSqlCommand(sql, 99.97M, "Ace Plumbing");
                rowCount += context.Database.ExecuteSqlCommand(sql, 43.83M, "Joe's Trash Service");
                Console.WriteLine("{0} rows inserted", rowCount);
            }
            using (DataContext context = new DataContext())
            // retrieve and materialize data using (var context = new EFRecipesEntities())
            {
                Console.WriteLine("Payments");
                Console.WriteLine("========");
                foreach (var payment in context.Payments)
                {
                    Console.WriteLine("Paid {0} to {1}", payment.Amount.ToString(),
                    payment.Vendor);
                }
            }

            // explicitly using SQL Parameter
            using (DataContext context = new DataContext())
            {
                var sql = @"Insert into Payments(Amount, Vendor) values (@amount, @vendor)";
                var rowCount = context.Database.ExecuteSqlCommand(sql, new SqlParameter("@amount", 458.47), new SqlParameter("@vendor", "Trolley Creatives"));
                rowCount += context.Database.ExecuteSqlCommand(sql, new SqlParameter("@amount", 743.23), new SqlParameter("@vendor", "Joe's Pixwork supplies"));
                Console.WriteLine("{0} rows inserted", rowCount);
            }
            using (DataContext context = new DataContext())
            // retrieve and materialize data using (var context = new EFRecipesEntities())
            {
                Console.WriteLine("Payments");
                Console.WriteLine("========");
                foreach (var payment in context.Payments)
                {
                    Console.WriteLine("Paid {0} to {1}", payment.Amount.ToString(),
                    payment.Vendor);
                }
            }

            Console.ReadKey();
        }
    }
}