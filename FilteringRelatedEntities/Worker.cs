using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilteringRelatedEntities
{
    public class Worker
    {
        public Worker()
        {
            this.Accidents = new HashSet<Accident>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Accident> Accidents { get; set; }
    }
}
