using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace FetchingObjectsWithNativeSQLStatements
{
    class Program
    {
        static void Main(string[] args)
        {

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

            using (var context = new DataContext())
            {
                //string sql = "SELECT * FROM Students WHERE Degree = @Major";

                // explicitly enumerate the columns
                string sql = "SELECT Id, FirstName, LastName, Degree FROM Students WHERE Degree = @Major";
                var parameters = new DbParameter[] 
                {
                    new SqlParameter {ParameterName = "Major", Value = "Masters"}
                };
                var students = context.Students.SqlQuery(sql, parameters);
                Console.WriteLine("Students...");
                foreach (var student in students)
                {
                    Console.WriteLine("{0} {1} is working on a {2} degree",
                    student.FirstName, student.LastName, student.Degree);
                }
            }

            Console.ReadKey();
        }
    }
}
