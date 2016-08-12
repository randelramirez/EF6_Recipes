using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturningMultipleResultSetsFromAStoredProcedure
{
    // You have a stored procedure that returns multiple result sets, and you want to materialize entities from each result set.
    class Program
    {
        static void Main(string[] args)
        {
            // initialize and seed the database
            using (DataContext context = new DataContext())
            {
                var job1 = new Job { Details = "Re-surface Parking Log" };
                var job2 = new Job { Details = "Build Driveway" };
                job1.Bids.Add(new Bid { Amount = 948M, Bidder = "ABC Paving" });
                job1.Bids.Add(new Bid { Amount = 1028M, Bidder = "TopCoat Paving" });
                job2.Bids.Add(new Bid { Amount = 502M, Bidder = "Ace Concrete" });
                context.Jobs.Add(job1);
                context.Jobs.Add(job2);
                context.SaveChanges();
            }

            // create stored procedure
            using (DataContext context =  new DataContext())
            {
                //string storedProcedure = " create procedure GetBidDetails as begin "
                //    + "select* from Jobs " 
                //    + "select* from Bids end";

                var storedProcedureBuilder = new StringBuilder();
                storedProcedureBuilder.AppendLine("create procedure GetBidDetails");
                storedProcedureBuilder.AppendLine("as");
                storedProcedureBuilder.AppendLine("begin");
                storedProcedureBuilder.AppendLine("select * from Jobs");
                storedProcedureBuilder.AppendLine("select * from Bids");
                storedProcedureBuilder.AppendLine("end");

                context.Database.ExecuteSqlCommand(storedProcedureBuilder.ToString());
            }

            using (var context = new DataContext())
            {
                var conn = context.Database.Connection;
                var cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetBidDetails";
                conn.Open();
                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                var jobs = ((IObjectContextAdapter)context).ObjectContext.Translate<Job>(reader, "Jobs",
                MergeOption.AppendOnly).ToList();
                reader.NextResult();
                ((IObjectContextAdapter)context).ObjectContext.Translate<Bid>(reader, "Bids",
                MergeOption.AppendOnly).ToList();
                foreach (var job in jobs)
                {
                    Console.WriteLine("\nJob: {0}", job.Details);
                    foreach (var bid in job.Bids)
                    {
                        Console.WriteLine("\tBid: {0} from {1}",
                        bid.Amount.ToString("C"), bid.Bidder);
                    }
                }
            }
            Console.ReadKey();

            /*
            This pattern involves creating a SqlConnection, SqlCommand
            setting the command text to the name of the stored procedure and calling ExecuteReader() to get a data reader.
            With a reader in hand, we use the Translate() method from the ObjectContext to materialize instances of the
            Job entity from the reader. This method takes a reader; the entity set name, and a merge option. The entity set name
            is required because an entity can live in multiple entity sets. Entity Framework needs to know which to use.

            The merge option parameter is a little more interesting. Using MergeOption.AppendOnly causes the new instances
            to be added to the object context and tracked. We use this option because we want to use Entity Framework’s entity
            span to fix up the associations automatically between jobs and bids. For this to happen, we simply add to the context
            all of the jobs and all of the bids. Entity Framework will automatically associate the bids to the right jobs. This saves us
            a great deal of tedious code.
             */
        }
    }
}
