using System.Collections.Generic;

namespace FlatteningQueryResults
{
    public class Associate
    {
        public Associate()
        {
            this.AssociateSalaries = new HashSet<AssociateSalary>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<AssociateSalary> AssociateSalaries { get; set; }
    }
}
