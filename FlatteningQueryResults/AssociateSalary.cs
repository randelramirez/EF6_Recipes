using System;

namespace FlatteningQueryResults
{
    public class AssociateSalary
    {
        public int Id { get; set; }

        public int AssociateId { get; set; }

        public decimal Salary { get; set; }

        public DateTime SalaryDate { get; set; }

        public virtual Associate Associate { get; set; }
    }
}
