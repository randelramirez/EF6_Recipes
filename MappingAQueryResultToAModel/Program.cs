using System;

namespace MappingAQueryResultToAModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize and seed the database
            using (DataContext context = new DataContext())
            {
                // insert student data
                context.Students.Add(new Student
                {
                    FirstName = "Robert",
                    LastName = "Smith",
                    Degree = "Masters"
                });
                context.Students.Add(new Student
                {
                    FirstName = "Julia",
                    LastName = "Kerns",
                    Degree = "Masters"
                });
                context.Students.Add(new Student
                {
                    FirstName = "Nancy",
                    LastName = "Stiles",
                    Degree = "Doctorate"
                });
                context.SaveChanges();
            }

            using (DataContext context = new DataContext())
            {
                string sql = "SELECT FirstName, LastName FROM Students";
                
                // note: StudentName is not a part of our entities 
                // the query returned from the sql query matches the model
                var StudentNames = context.Database.SqlQuery<StudentName>(sql);
                foreach (var name in StudentNames)
                {
                    Console.WriteLine("FirstName: {0} LastName: {1}", name.FirstName, name.LastName);
                }
            }

                Console.ReadKey();
        }
    }
}
