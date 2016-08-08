using System;

namespace SplittingAnEntityAmongMultipleTables
{
    class Program
    {
        // Problem: You have two or more tables that share the same primary key, and you want to map a single entity to these two tables.
        // This process is called vertical Splitting

        static void Main(string[] args)
        {
            using (DataContext context = new DataContext())
            {
                var person1 = new Person
                {
                    Id = 123,
                    FirstName = "Randel",
                    LastName = "Ramirez",
                    Birthday = new DateTime(1989, 4, 26),
                    FavoriteColor = "Red",
                    FavoriteFood = "Pizza",
                    FavoriteQuote = "Luck is truly where preparation meets oppurtunity",
                };

                var person2 = new Person
                {
                    Id = 980,
                    FirstName = "Kobe",
                    LastName = "Bryant",
                    Birthday = new DateTime(1989, 4, 26),
                    FavoriteColor = "Purple and Gold",
                    FavoriteFood = "Burger",
                    FavoriteQuote = "The Black Mamba",
                };

                context.People.Add(person1);
                context.People.Add(person2);
                context.SaveChanges();

                var queryable = context.People;
                // The downside of vertical splitting is that retrieving each instance of our entity now requires an additional join for each additional table that makes up the entity type
            }
                Console.ReadKey();
        }
    }
}
