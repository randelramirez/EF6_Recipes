using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_a_And_Has_a_Relationships
{
    public class Park : Location
    {
        public string Name { get; set; }

        public int? OfficeLocationId { get; set; }

        public virtual Location Office { get; set; }


    }
}
