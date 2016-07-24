using System.Collections.Generic;

namespace SelfReferencingFluentApi
{
    public class Employee
    {
        public Employee()
        {
            this.Subordinates = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? Supervisor { get; set; }

        public Employee SupervisorEmployee { get; set; }

        public ICollection<Employee> Subordinates { get; set; }
    }
}
