using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringRelatedEntities
{
    public class Accident
    {
        public int Id { get; set; }

        public int WorkerId { get; set; }

        public string Description { get; set; }

        public int? Severity { get; set; }

        public Worker Worker { get; set; }

    }
}
