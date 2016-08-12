using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReturningMultipleResultSetsFromAStoredProcedure
{
    public class Job
    {
        public Job()
        {
            this.Bids = new HashSet<Bid>();
        }

        public int Id { get; set; }

        public string Details { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}
