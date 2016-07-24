using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelfReferencingDataAnnotation
{
    public class Employee
    {
        public Employee()
        {
            this.Subordinates = new HashSet<Employee>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Supervisor { get; set; }

        [ForeignKey("Supervisor")]
        public Employee SupervisorEmployee { get; set; }

        public ICollection<Employee> Subordinates { get; set; }
    }
}
