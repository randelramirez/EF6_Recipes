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

            #region notes
            /*
                To retrieve the Students who are working on a master’s degree, we use the SqlQuery() method with a
                parameterized SQL statement and a parameter set to “Masters.” We iterate through the returned collection of Students
                and print each of them. Note that the associated context object implements change tracking for these values.
                Here we use * in place of explicitly naming each column in the select statement. This works because the columns
                in the underlying table match the properties in the Student entity type. Entity Framework will match the returned
                values to the appropriate properties. This works fine in most cases, but if fewer columns returned from your query,
                Entity Framework will throw an exception during the materialization of the object. A much better approach and best
                practice is to enumerate the columns explicitly (that is, specify each column name) in your SQL statement.
                If your SQL statement returns more columns than required to materialize the entity (that is, more column values
                than properties in the underlying entity object), Entity Framework will happily ignore the additional columns. If you
                think about this for a moment, you’ll realize that this isn’t a desirable behavior. Again, consider explicitly enumerating
                the expected columns in your SQL statement to ensure they match your entity type.
                
                There are some restrictions around the SqlQuery() method. If you are using Table per Hierarchy inheritance and
                your SQL statement returns rows that could map to different derived types, Entity Framework will not be able to use
                the discriminator column to map the rows to the correct derived types. You will likely get a runtime exception because
                some rows don’t contain the values required for the type being materialized.
                
                Interestingly, you can use SqlQuery() to materialize objects that are not entities at all. For example, we could
                create a StudentName class that contains just first and last names of a student. If our SQL statement returned just these
                two strings, we could use SqlQuery<StudentName>() along with our SQL statement to fetch a collection of instances of
                StudentName.

                We’ve been careful to use the phrase SQL statement rather than select statement because the SqlQuery()
                method works with any SQL statement that returns a row set. This includes, of course, Select statements, but it can
                also include statements that execute stored procedures.
             */

            #endregion

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
