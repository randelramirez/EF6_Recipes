using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_a_And_Has_a_Relationships
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new DataContext())
            {
                var park = new Park
                {
                    Name = "11th Street Park",
                    Address = "801 11th Street",
                    City = "Aledo",
                    State = "TX",
                    ZIPCode = "76106"
                };
                var loc = new Location
                {
                    Address = "501 Main",
                    City = "Weatherford",
                    State = "TX",
                    ZIPCode = "76201"
                };
                park.Office = loc;
                context.Locations.Add(park);
                park = new Park
                {
                    Name = "Overland Park",
                    Address = "101 High Drive",
                    City = "Springtown",
                    State = "TX",
                    ZIPCode = "76081"
                };
                loc = new Location
                {
                    Address = "8705 Range Lane",
                    City = "Springtown",
                    State = "TX",
                    ZIPCode = "76081"
                };
                park.Office = loc;
                context.Locations.Add(park);
                context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
