using System;

namespace SelfReferencingFluentApi
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new DataContext())
            {
                var manager = new Employee { Name = "Manager" };

                var teamLead1 = new Employee { Name = "Team lead 1", SupervisorEmployee = manager };
                var employee1 = new Employee { Name = "regular1", SupervisorEmployee = teamLead1 };
                var employee2 = new Employee { Name = "regular2", SupervisorEmployee = teamLead1 };
                var employee3 = new Employee { Name = "regular3", SupervisorEmployee = teamLead1 };
                var employee4 = new Employee { Name = "regular4", SupervisorEmployee = teamLead1 };

                var teamLead2 = new Employee { Name = "Team lead2 2", SupervisorEmployee = manager };
                var employee5 = new Employee { Name = "regular5", SupervisorEmployee = teamLead2 };
                var employee6 = new Employee { Name = "regular6", SupervisorEmployee = teamLead2 };

                context.Employees.Add(manager);
                context.Employees.Add(teamLead1);
                context.Employees.Add(employee1);
                context.Employees.Add(employee2);
                context.Employees.Add(employee3);
                context.Employees.Add(employee4);
                context.Employees.Add(teamLead2);
                context.Employees.Add(employee5);
                context.Employees.Add(employee6);
                context.SaveChanges();

                Console.WriteLine("People under manager");
                foreach (var subordinate in manager.Subordinates)
                {
                    Console.WriteLine(subordinate.Name);
                }
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Supervisor of team lead 1: " + teamLead1.SupervisorEmployee.Name);
                foreach (var subordinate in teamLead1.Subordinates)
                {
                    Console.WriteLine(subordinate.Name);
                }
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Supervisor of team lead 2: " + teamLead2.SupervisorEmployee.Name);
                foreach (var subordinate in teamLead2.Subordinates)
                {
                    Console.WriteLine(subordinate.Name);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
